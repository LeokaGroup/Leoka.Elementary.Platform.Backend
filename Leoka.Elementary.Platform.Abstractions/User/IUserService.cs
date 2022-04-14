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
    /// <param name="userEmail">Email пользователя.</param>
    /// <param name="roleSysName">Системное название роли.</param>
    /// <param name="userPhoneNumber">Номер телефона.</param>
    /// <returns>Данные пользователя.</returns>
    Task<UserOutput> CreateUserAsync(string name, string userEmail, string userRole, string userPhoneNumber);

    /// <summary>
    /// Метод авторизует пользователя.
    /// </summary>
    /// <param name="userLogin">Email или номер телефона.</param>
    /// <param name="userPassword">Пароль.</param>
    /// <returns>Данные пользователя.</returns>
    Task<ClaimOutput> SignInAsync(string userLogin, string userPassword);

    /// <summary>
    /// Метод отправит пользователя на страницу успешного подтверждения почты.
    /// </summary>
    /// <param name="code">Код подтверждения (guid).</param>
    /// <returns>Редиректит на страницу успеха.</returns>
    Task<bool> ConfirmEmailAccountCode(string code);
}