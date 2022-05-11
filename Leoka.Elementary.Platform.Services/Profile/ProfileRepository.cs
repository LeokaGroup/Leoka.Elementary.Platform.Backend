using Leoka.Elementary.Platform.Abstractions.Profile;
using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Models.Profile.Output;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.Services.Profile;

/// <summary>
/// Класс реализует методы репозитория профиля пользователя.
/// </summary>
public sealed class ProfileRepository : IProfileRepository
{
    private readonly PostgreDbContext _dbContext;
    
    public ProfileRepository(PostgreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Метод получит информацию для профиля пользователя при входе после регитсрации.
    /// </summary>
    /// <returns>Данные о профиле.</returns>
    public async Task<ProfileInfoOutput> GetProfileInfoAsync()
    {
        try
        {
            var result = await _dbContext.ProfileInfos
                .Select(p => new ProfileInfoOutput
                {
                    ProfileInfoTitle = p.ProfileInfoTitle,
                    ProfileInfoText = p.ProfileInfoText,
                    IsVisibleInfo = p.IsVisibleInfo
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
    /// Метод получит список элементов для меню профиля пользователя.
    /// </summary>
    /// <param name="roleId">Id роли.</param>
    /// <returns>Список элементов меню.</returns>
    public async Task<ProfileMenuItemResult> GetProfileMenuItemsAsync(int roleId)
    {
        try
        {
            var items = await _dbContext.ProfileMenuItems
                .Where(i => i.RoleId == roleId && !new[] { -1, 0 }.Contains(roleId))
                .Select(i => new ProfileMenuItemResult
                {
                    ProfileLeftMenuItems = _dbContext.ProfileMenuItems
                        .Where(a => a.MenuType == 1)
                        .Select(a => new ProfileMenuItemOutput
                        {
                            ProfileItemTitle = a.ProfileItemTitle,
                            Position = a.Position,
                            ProfileItemSysName = a.ProfileItemSysName,
                            ProfileItemUrl = a.ProfileItemUrl,
                            IsSelectItem = a.IsSelectItem,
                            IconUrl = a.IconUrl,
                            MenuType = a.MenuType,
                            IsVisibleBalance = a.IsVisibleBalance,
                            IsDropdown = a.IsDropdown
                        })
                        .OrderBy(o => o.Position)
                        .ToList(),
                    ProfileHeaderMenuItems = _dbContext.ProfileMenuItems
                        .Where(b => b.MenuType == 2)
                        .Select(b => new ProfileMenuItemOutput
                        {
                            ProfileItemTitle = b.ProfileItemTitle,
                            Position = b.Position,
                            ProfileItemSysName = b.ProfileItemSysName,
                            ProfileItemUrl = b.ProfileItemUrl,
                            IsSelectItem = b.IsSelectItem,
                            IconUrl = b.IconUrl,
                            MenuType = b.MenuType,
                            IsVisibleBalance = b.IsVisibleBalance,
                            IsDropdown = b.IsDropdown
                        })
                        .OrderBy(o => o.Position)
                        .ToList(),
                    ProfileDropdownMenuItems = _dbContext.ProfileMenuItems
                        .Where(c => c.MenuType == 3)
                        .Select(c => new ProfileMenuItemOutput
                        {
                            ProfileItemTitle = c.ProfileItemTitle,
                            Position = c.Position,
                            ProfileItemSysName = c.ProfileItemSysName,
                            ProfileItemUrl = c.ProfileItemUrl,
                            IsSelectItem = c.IsSelectItem,
                            IconUrl = c.IconUrl,
                            MenuType = c.MenuType,
                            IsVisibleBalance = c.IsVisibleBalance,
                            IsDropdown = c.IsDropdown
                        })
                        .OrderBy(o => o.Position)
                        .ToList()
                })
                .FirstOrDefaultAsync();

            return items;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит список предметов.
    /// </summary>
    /// <returns>Список предметов.</returns>
    public async Task<IEnumerable<ProfileItemOutput>> GetProfileItemsAsync()
    {
        try
        {
            var result = await _dbContext.ProfileItems
                .Select(pi => new ProfileItemOutput
                {
                    ItemName = pi.ItemName,
                    ItemSysName = pi.ItemSysName,
                    ItemNumber = pi.ItemNumber,
                    Position = pi.Position
                })
                .OrderBy(o => o.Position)
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
}