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
    /// <param name="messageBody">Тело сообщения.</param>
    /// <param name="messageTitle">Заголовок сообщения.</param>
    Task SendConfirmEmailAsync(string mailTo, string userAccount, string userPassword);
}