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
    /// <param name="userEmail">Email пользователя.</param>
    /// <param name="roleSysName">Системное название роли.</param>
    /// <param name="userPhoneNumber">Номер телефона.</param>
    /// <returns>Данные пользователя.</returns>
    Task<UserOutput> CreateUserAsync(string name, string userEmail, string userRole, string userPhoneNumber);

    /// <summary>
    /// Метод получит Id оли по ее системному имени.
    /// </summary>
    /// <param name="sysName">Системное имя роли.</param>
    /// <returns>Id роли.</returns>
    Task<int> GetRoleIdBySysNameAsync(string sysName);
    
    /// <summary>
    /// Метод авторизует пользователя.
    /// </summary>
    /// <param name="userLogin">Email или номер телефона.</param>
    /// <param name="userPassword">Пароль.</param>
    /// <returns>Статус авторизации.</returns>
    Task<bool> SignInAsync(string userLogin, string userPassword);

    /// <summary>
    /// Метод найдет пользователя по его email.
    /// </summary>
    /// <param name="userEmail">Email пользователя.</param>
    /// <returns>Данные пользователя.</returns>
    Task<UserOutput> GetUserByEmailAsync(string userEmail);

    /// <summary>
    /// Метод обновит пароль поьзователя по его UserId или UserCode.
    /// </summary>
    /// <param name="id">UserId или UserCode пользователя.</param>
    /// <param name="passwordHash">Пароль пользователя.</param>
    Task UpdateUserPasswordAsync(string id, string passwordHash);
    
    /// <summary>
    /// Метод отправит пользователя на страницу успешного подтверждения почты.
    /// </summary>
    /// <param name="code">Код подтверждения (guid).</param>
    /// <returns>Редиректит на страницу успеха.</returns>
    Task<bool> ConfirmEmailAccountCode(string code);

    /// <summary>
    /// Метод найдет Id пользователя по его коду.
    /// </summary>
    /// <param name="userCode">Код пользователя.</param>
    /// <returns>Id пользователя.</returns>
    Task<long> GetUserIdByUserCodeAsync(string userCode);
}