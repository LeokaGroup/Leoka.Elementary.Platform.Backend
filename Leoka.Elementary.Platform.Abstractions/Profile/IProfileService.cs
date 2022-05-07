using Leoka.Elementary.Platform.Models.Profile.Output;

namespace Leoka.Elementary.Platform.Abstractions.Profile;

/// <summary>
/// Абстракция сервиса профиля пользователя.
/// </summary>
public interface IProfileService
{
    /// <summary>
    /// Метод получит информацию для профиля пользователя при входе после регитсрации.
    /// </summary>
    /// <returns>Данные о профиле.</returns>
    Task<ProfileInfoOutput> GetProfileInfoAsync();

    /// <summary>
    /// Метод получит список элементов для меню профиля пользователя.
    /// <param name="account">Аккаунт пользователя.</param>
    /// </summary>
    /// <returns>Список элементов меню.</returns>
    Task<ProfileMenuItemResult> GetProfileMenuItemsAsync(string account);
}