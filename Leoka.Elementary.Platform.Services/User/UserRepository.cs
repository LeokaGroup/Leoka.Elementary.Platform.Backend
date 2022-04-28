using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Backend.Core.Data;
using Leoka.Elementary.Platform.Base.Abstraction;
using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Core.Exceptions;
using Leoka.Elementary.Platform.Core.Utils;
using Leoka.Elementary.Platform.Models.Entities.User;
using Leoka.Elementary.Platform.Models.User.Output;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Leoka.Elementary.Platform.Services.User;

/// <summary>
/// Класс реализует методы репозитория пользователя при работе с БД.
/// </summary>
public sealed class UserRepository : IUserRepository
{
    private readonly PostgreDbContext _postgreDbContext;

    public UserRepository(PostgreDbContext postgreDbContext)
    {
        _postgreDbContext = postgreDbContext;
    }

    /// <summary>
    /// Метод создаст нового пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="userEmail">Email пользователя.</param>
    /// <param name="roleSysName">Системное название роли.</param>
    /// <param name="userPhoneNumber">Номер телефона.</param>
    /// <returns>Данные пользователя.</returns>
    public async Task<UserOutput> CreateUserAsync(string name, string userEmail, string userRole, string userPhoneNumber)
    {
        try
        {
            // Проверит существование пользователя по Email.
            var checkUserByEmail = await _postgreDbContext.Users.Where(u => u.UserName.Equals(userEmail)).AnyAsync();

            if (checkUserByEmail)
            {
                // TODO: пишем такое в логи.
                throw new DublicateUserException();
            }
            
            // Проверит существование пользователя по номеру телефона.
            var checkUserByPhoneNumber = await _postgreDbContext.Users.Where(u => u.PhoneNumber.Equals(userPhoneNumber)).AnyAsync();
            
            if (checkUserByPhoneNumber)
            {
                // TODO: пишем такое в логи.
                throw new DublicateUserException();
            }
            
            var now = DateTime.UtcNow;
            var addUser = new UserEntity
            {
                UserCode = Guid.NewGuid().ToString(),
                UserName = userEmail,
                FirstName = name,
                LastName = string.Empty,
                SecondName = string.Empty,
                Email = userEmail,
                PhoneNumber = userPhoneNumber,
                DateRegister = now,
                ConfirmEmailCode = Guid.NewGuid().ToString()
            };
            await _postgreDbContext.Users.AddAsync(addUser);
            await _postgreDbContext.SaveChangesAsync();
            
            var userId = await GetUserIdByUserCodeAsync(addUser.UserCode);

            var result = new UserOutput
            {
                UserName = userEmail,
                FirstName = name,
                LastName = string.Empty,
                SecondName = string.Empty,
                Email = userEmail,
                PhoneNumber = userPhoneNumber,
                DateRegister = now,
                Successed = true,
                ConfirmEmailCode = addUser.ConfirmEmailCode,
                UserId = userId >= 0 ? userId : 0
            };

            // Назначит роль пользователю.
            var roleId = await GetRoleIdBySysNameAsync(userRole);

            await _postgreDbContext.UserRoles.AddAsync(new UserRoleEntity
            {
                RoleId = roleId
            });
            await _postgreDbContext.SaveChangesAsync();

            

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит Id оли по ее системному имени.
    /// </summary>
    /// <param name="sysName">Системное имя роли.</param>
    /// <returns>Id роли.</returns>
    public async Task<int> GetRoleIdBySysNameAsync(string sysName)
    {
        try
        {
            if (string.IsNullOrEmpty(sysName))
            {
                throw new EmptyRoleSysNameException();
            }

            var result = await _postgreDbContext.Roles
                .Where(r => r.RoleSysName.Equals(sysName))
                .FirstOrDefaultAsync();

            if (result != null)
            {
                return result.RoleId;
            }

            throw new NotFoundRoleSysNameException(sysName);
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ClaimOutput> SignInAsync(string userLogin, string userPassword)
    {
        try
        {
            // Ищет пользователя по email или номеру телефона.
            var findUser = _postgreDbContext.Users.AsQueryable();
            
            if (userLogin.Contains('@'))
            {
                findUser = findUser.Where(u => u.Email.Equals(userLogin));
            }

            else
            {
                findUser = findUser.Where(u => u.PhoneNumber.Equals(userLogin));
            }

            var checkUser = await findUser.FirstOrDefaultAsync();
            
            if (checkUser == null)
            {
                throw new ErrorUserAuthorizeException(userLogin);
            }
            
            var commonService = AutoFac.Resolve<ICommonService>();
            var checkPassword = await commonService.VerifyHashedPassword(checkUser.PasswordHash, userPassword);

            // Если пароль неверен.
            if (!checkPassword)
            {
                throw new ErrorUserPasswordException();
            }
            
            var claim = GetIdentityClaim(userLogin);
            
            // Генерация токен юзеру.
            var token = GenerateToken(claim).Result;

            var result = new ClaimOutput
            {
                User = userLogin,
                Token = token,
                IsSuccess = true
            };

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод выдаст токен пользователю, если он прошел авторизацию.
    /// </summary>
    /// <param name="email">Email.</param>
    /// <returns>Токен пользователя.</returns>
    private ClaimsIdentity GetIdentityClaim(string email)
    {
        var claims = new List<Claim> {
            new Claim(ClaimsIdentity.DefaultNameClaimType, email)
            //new Claim(JwtRegisteredClaimNames.UniqueName, username)
        };

        var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

        return claimsIdentity;
    }
    
    /// <summary>
    /// Метод генерит токен юзеру.
    /// </summary>
    /// <param name="claimsIdentity">Объект полномочий.</param>
    /// <returns>Строку токена.</returns>
    private Task<string> GenerateToken(ClaimsIdentity claimsIdentity)
    {
        try
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Task.FromResult(encodedJwt);
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    /// <summary>
    /// Метод найдет пользователя по его email.
    /// </summary>
    /// <param name="userEmail">Email пользователя.</param>
    /// <returns>Данные пользователя.</returns>
    public async Task<UserOutput> GetUserByEmailAsync(string userEmail)
    {
        try
        {
            var result = await _postgreDbContext.Users
                .Where(u => u.Email.Equals(userEmail))
                .Select(u => new UserOutput
                {
                    DateRegister = u.DateRegister,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SecondName = u.SecondName,
                    PhoneNumber = u.PhoneNumber,
                    UserName = u.UserName,
                    UserId = u.UserId,
                    UserCode = u.UserCode
                })
                .FirstOrDefaultAsync();

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод обновит пароль поьзователя по его UserId или UserCode.
    /// </summary>
    /// <param name="id">UserId или UserCode пользователя.</param>
    /// <param name="passwordHash">Пароль пользователя.</param>
    public async Task UpdateUserPasswordAsync(string id, string passwordHash)
    {
        try
        {
            var isParseNumber = long.TryParse(id, out _);
            UserEntity user = null;
            
            // Если передали UserId.
            if (isParseNumber)
            {
                user = await _postgreDbContext.Users.FirstOrDefaultAsync(u => u.UserId == Convert.ToInt64(id));
            }

            // Если передали UserCode.
            else
            {
                user = await _postgreDbContext.Users.FirstOrDefaultAsync(u => u.UserCode.Equals(id));
            }
            
            if (user is not null)
            {
                user.PasswordHash = passwordHash;
                await _postgreDbContext.SaveChangesAsync();
            }
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод отправит пользователя на страницу успешного подтверждения почты.
    /// </summary>
    /// <param name="code">Код подтверждения (guid).</param>
    /// <returns>Редиректит на страницу успеха.</returns>
    public async Task<bool> ConfirmEmailAccountCode(string code)
    {
        try
        {
            var user = await _postgreDbContext.Users.Where(u => u.ConfirmEmailCode.Equals(code)).FirstOrDefaultAsync();

            if (user == null)
            {
                return false;
            }

            user.EmailConfirmed = true;
            await _postgreDbContext.SaveChangesAsync();

            return true;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод найдет Id пользователя по его коду.
    /// </summary>
    /// <param name="userCode">Код пользователя.</param>
    /// <returns>Id пользователя.</returns>
    public async Task<long> GetUserIdByUserCodeAsync(string userCode)
    {
        try
        {
            if (string.IsNullOrEmpty(userCode))
            {
                throw new NotFoundUserCodeException(userCode);
            }

            var result = await _postgreDbContext.Users
                .Where(u => u.UserCode.Equals(userCode))
                .Select(u => u.UserId)
                .FirstOrDefaultAsync();

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}