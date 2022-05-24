using Leoka.Elementary.Platform.Models.Profile.Output;
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

    /// <summary>
    /// Метод получит список файлов сертификатов с сервера.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="certsUrls">Названия файлов сертификатов.</param>
    /// <returns>Список файлов.</returns>
    Task<IEnumerable<FileContentResultOutput>> GetUserCertsFilesAsync(long userId, string[] certsNames);

    /// <summary>
    /// Метод получит аватар профиля пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="avatar">Изображение аватара.</param>
    /// <returns>Аватар профиля пользователя.</returns>
    Task<FileContentAvatarOutput> GetProfileAvatarAsync(long userId, string avatar);
}