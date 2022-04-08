using Leoka.Elementary.Platform.Models.User.Output;

namespace Leoka.Elementary.Platform.Abstractions.User;

/// <summary>
/// Абстракция сервиса пользователей.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Метод создаст нового пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="contactData">Контактные данные пользователя (email или телефон).</param>
    /// <param name="roleSysName">Системное название роли.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Данные пользователя.</returns>
    Task<UserOutput> CreateUserAsync(string name, string contactData, string userRole, string password);
}