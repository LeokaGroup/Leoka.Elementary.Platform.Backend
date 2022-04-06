using Leoka.Elementary.Platform.Models.User.Output;

namespace Leoka.Elementary.Platform.Abstractions.User;

/// <summary>
/// Абстракция репозитория пользователя для работы с БД.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Метод создаст нового пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="email">Email.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="roleSysName">Системное название роли.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Данные пользователя.</returns>
    Task<UserOutput> CreateUserAsync(string name, string email, string phoneNumber, string roleSysName, string password);

    /// <summary>
    /// Метод получит Id оли по ее системному имени.
    /// </summary>
    /// <param name="sysName">Системное имя роли.</param>
    /// <returns>Id роли.</returns>
    Task<int> GetRoleIdBySysNameAsync(string sysName);
}