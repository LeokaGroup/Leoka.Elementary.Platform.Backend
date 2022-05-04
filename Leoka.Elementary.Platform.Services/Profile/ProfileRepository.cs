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
}