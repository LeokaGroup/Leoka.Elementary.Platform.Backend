using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Core.Exceptions;
using Leoka.Elementary.Platform.Core.Utils;
using Leoka.Elementary.Platform.Models.Entities.User;
using Leoka.Elementary.Platform.Models.User.Output;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.Services.User;

/// <summary>
/// Класс реализует методы репозитория пользователя при работе с БД.
/// </summary>
public sealed class UserRepository : IUserRepository
{
    private readonly PostgreDbContext _postgreDbContext;
    private readonly UserManager<UserEntity> _userManager;
    
    public UserRepository(PostgreDbContext postgreDbContext,
        UserManager<UserEntity> userManager)
    {
        _postgreDbContext = postgreDbContext;
        _userManager = userManager;
    }

    /// <summary>
    /// Метод создаст нового пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="email">Email.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="roleSysName">Системное название роли.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Данные пользователя.</returns>
    public async Task<UserOutput> CreateUserAsync(string name, string email, string phoneNumber, string roleSysName, string password)
    {
        try
        {
            var maxUserId = await _postgreDbContext.Users
                .Select(u => u.UserId)
                .DefaultIfEmpty()
                .MaxAsync();
            
            if (maxUserId <= 0)
            {
                maxUserId = 1;
            }

            var addUser = await _userManager.CreateAsync(new UserEntity
            {
                UserId = Convert.ToInt64(maxUserId),
                UserName = email,
                FirstName = name,
                LastName = string.Empty,
                SecondName = string.Empty,
                Email = email,
                DateRegister = DateTime.UtcNow,
                LockoutEnabled = false
            }, password);
            
            var result = new UserOutput
            {
                UserName = email,
                FirstName = name,
                LastName = string.Empty,
                SecondName = string.Empty,
                Email = email
            };
            
            if (addUser.Succeeded)
            {
                result.DateRegister = DateTime.Now;
                result.Successed = true;
                
                // Назначит роль пользователю.
                var roleId = await GetRoleIdBySysNameAsync(roleSysName);

                await _postgreDbContext.UserRoles.AddAsync(new UserRoleEntity
                {
                    RoleId = roleId
                });
                await _postgreDbContext.SaveChangesAsync();
            }

            // Соберет список ошибок для вывода фронту. 
            else
            {
                foreach (var error in addUser.Errors)
                {
                    result.Errors.Add(error);
                }

                result.Failure = true;
            }

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
}