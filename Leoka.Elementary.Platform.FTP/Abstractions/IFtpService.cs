using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    /// <summary>
    /// Метод получит список файлов сертификатов с сервера.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="certsUrls">Названия файлов сертификатов.</param>
    /// <returns>Список файлов.</returns>
    Task<IEnumerable<FileContentResult>> GetUserCertsFilesAsync(long userId, string[] certsNames);
}