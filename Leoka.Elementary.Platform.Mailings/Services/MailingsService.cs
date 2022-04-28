using Leoka.Elementary.Platform.Mailings.Abstractions;
using Leoka.Elementary.Platform.Mailings.Exceptions;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Leoka.Elementary.Platform.Mailings.Services;

/// <summary>
/// Сервис реализует методы сервиса рассылок.
/// </summary>
public sealed class MailingsService : IMailingsService
{
    private readonly IConfiguration _configuration;

    public MailingsService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Метод отправит подтверждение на почту.
    /// </summary>
    /// <param name="mailTo">Email кому отправить.</param>
    /// <param name="userAccount">Аккаунт пользователя..</param>
    /// <param name="userPassword">Пароль пользователя.</param>
    /// <param name="confirmEmailCode">Код подтверждения почты.</param>
    public async Task SendConfirmEmailAsync(string mailTo, string userAccount, string userPassword, string confirmEmailCode)
    {
        try
        {
            // Проверит параметры.
            GenerateMailException(mailTo, userAccount, userPassword, confirmEmailCode);
            
            var email = _configuration["MailingsSettings:EmailFrom"];
            var password = _configuration["MailingsSettings:Password"];
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration["MailingsSettings:EmailAdministrator"], email));
            emailMessage.To.Add(new MailboxAddress(mailTo, mailTo));
            emailMessage.Subject = "Активируйте аккаунт.";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {//TODO: заменить ссылку на получение из БД.
                Text =
                    $"Для завершения регистрации перейдите по ссылке <a href='http://localhost:9991/user/confirm-email?code={confirmEmailCode}'>Подтвердить аккаунт</a> </br>" +
                    "</br>" +
                    "<strong>Данные для входа.</strong> </br>" +
                    "Ваш логин: " + userAccount + "</br>" +
                    "Ваш текущий пароль: " + userPassword + "</br>" +
                    "<strong>Рекомендуем сменить пароль в настройках личного кабинета.</strong>"
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.mail.ru", 2525, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(email, password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }

        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод генерации исключения при проверке обязательных параметров при рассылке на почту.
    /// </summary>
    /// <param name="mailTo">Email кому отправить.</param>
    /// <param name="userAccount">Аккаунт пользователя..</param>
    /// <param name="userPassword">Пароль пользователя.</param>
    /// <param name="confirmEmailCode">Код подтверждения почты.</param>
    private void GenerateMailException(string mailTo, string userAccount, string userPassword, string confirmEmailCode)
    {
        // Если не передан email пользователя.
        if (string.IsNullOrEmpty(mailTo))
        {
            throw new EmptyMailParamException(mailTo);
        }

        // Если не передан аккаунт пользователя.
        if (string.IsNullOrEmpty(userAccount))
        {
            throw new EmptyMailParamException(userAccount);
        }

        // Если не передан пароль пользователя.
        if (string.IsNullOrEmpty(userPassword))
        {
            throw new EmptyMailParamException(userPassword);
        }

        // Если не передан код для подтверждения аккаунта пользователя.
        if (string.IsNullOrEmpty(confirmEmailCode))
        {
            throw new EmptyMailParamException(confirmEmailCode);
        }
    }
}