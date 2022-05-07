﻿using Leoka.Elementary.Platform.Access.Abstraction;
using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Models.Role.Output;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.Access.Service;

/// <summary>
/// Класс реализует методы репозитория ролей.
/// </summary>
public class RoleRepository : IRoleRepository
{
    private readonly PostgreDbContext _dbContext;
    
    public RoleRepository(PostgreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Метод получит список ролей.
    /// </summary>
    /// <returns>Список ролей.</returns>
    public async Task<IEnumerable<RoleOutput>> GetRolesAsync()
    {
        try
        {
            // Получит роли, кроме партнера и администратора.
            var result = await _dbContext.Roles
                .Where(r => !new[] { -1, 0 }.Contains(r.RoleId))
                .Select(r => new RoleOutput
                {
                    RoleSysName = r.RoleSysName,
                    RoleName = r.RoleName
                })
                .ToListAsync();

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
    /// Метод получит роль пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Id роли.</returns>
    public async Task<int> GetUserRoleAsync(long userId)
    {
        try
        {
            var roleId = await _dbContext.UserRoles
                .Where(r => r.UserRoleId == userId)
                .Select(r => r.RoleId)
                .FirstOrDefaultAsync();

            return roleId;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}