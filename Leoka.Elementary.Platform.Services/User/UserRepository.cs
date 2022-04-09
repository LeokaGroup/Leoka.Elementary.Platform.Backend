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
    /// <param name="contactData">Контактные данные пользователя (email или телефон).</param>
    /// <param name="roleSysName">Системное название роли.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Данные пользователя.</returns>
    public async Task<UserOutput> CreateUserAsync(string name, string contactData, string roleSysName, string passwordHash)
    {
        try
        {
            var addUser = new UserEntity
            {
                UserCode = Guid.NewGuid().ToString(),
                UserName = contactData,
                FirstName = name,
                LastName = string.Empty,
                SecondName = string.Empty,
                Email = contactData.Contains('@') ? contactData : string.Empty,
                DateRegister = DateTime.UtcNow,
                PasswordHash = passwordHash
            };
            await _postgreDbContext.Users.AddAsync(addUser);
            await _postgreDbContext.SaveChangesAsync();

            var result = new UserOutput
            {
                UserName = contactData,
                FirstName = name,
                LastName = string.Empty,
                SecondName = string.Empty,
                Email = contactData.Contains('@') ? contactData : string.Empty,
                DateRegister = DateTime.Now,
                Successed = true
            };

            // Назначит роль пользователю.
            var roleId = await GetRoleIdBySysNameAsync(roleSysName);

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
            var fineUser = _postgreDbContext.Users.AsQueryable();
            
            if (userLogin.Contains('@'))
            {
                fineUser = fineUser.Where(u => u.Email.Equals(userLogin));
            }

            else
            {
                fineUser = fineUser.Where(u => u.PhoneNumber.Equals(userLogin));
            }

            var checkUser = await fineUser.FirstOrDefaultAsync();
            
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
}