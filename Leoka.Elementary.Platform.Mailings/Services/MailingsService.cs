using Leoka.Elementary.Platform.Mailings.Abstractions;
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
    /// <param name="messageBody">Тело сообщения.</param>
    /// <param name="messageTitle">Заголовок сообщения.</param>
    public async Task SendConfirmEmailAsync(string mailTo, string userAccount, string userPassword)
    {
        try
        {
            var email = _configuration["MailingsSettings:EmailFrom"];
            var password = _configuration["MailingsSettings:Password"];
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration["MailingsSettings:EmailAdministrator"], email));
            emailMessage.To.Add(new MailboxAddress(mailTo, mailTo));
            emailMessage.Subject = "Активируйте аккаунт.";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Для завершения регистрации перейдите по ссылке <a href='#'>Тестовая ссылка</a> </br>" +
                       "</br>" +
                       "<strong>Данные для входа.</strong> </br>" +
                       "Ваш логин: " + userAccount + "</br>" +
                       "Ваш текущий пароль: " + userPassword + "</br>" +
                       "<strong>Рекомендуем сменить ваш пароль в настройках личного кабинета.</strong>" 
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
}