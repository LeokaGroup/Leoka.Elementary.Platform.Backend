using Microsoft.AspNetCore.Http;

namespace Leoka.Elementary.Platform.FTP.Abstractions;

/// <summary>
/// Абстракция FTP-сервиса.
/// </summary>
public interface IFtpService
{
    /// <summary>
    /// Метод загрузит файлы анкеты профиля пользователя по FTP на сервер.
    /// </summary>
    /// <param name="files">Файлы для отправки.</param>
    /// <param name="userId">Id пользователя.</param>
    Task UploadProfileFilesFtpAsync(IFormFileCollection files, long userId);
}