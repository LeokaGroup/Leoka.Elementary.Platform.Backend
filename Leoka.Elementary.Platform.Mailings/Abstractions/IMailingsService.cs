namespace Leoka.Elementary.Platform.Mailings.Abstractions;

/// <summary>
/// Абстракция сервиса рассылок.
/// </summary>
public interface IMailingsService
{
    /// <summary>
    /// Метод отправит подтверждение на почту.
    /// </summary>
    /// <param name="mailTo">Email кому отправить.</param>
    /// <param name="userAccount">Аккаунт пользователя..</param>
    /// <param name="userPassword">Пароль пользователя.</param>
    /// <param name="confirmEmailCode">Код подтверждения почты.</param>
    Task SendConfirmEmailAsync(string mailTo, string userAccount, string userPassword, string confirmEmailCode);
}