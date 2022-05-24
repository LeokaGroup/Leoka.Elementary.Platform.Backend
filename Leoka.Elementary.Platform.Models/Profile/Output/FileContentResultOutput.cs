using Microsoft.AspNetCore.Mvc;

namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели сертификатов пользователя.
/// </summary>
public class FileContentResultOutput
{
    /// <summary>
    /// Файл сертификата.
    /// </summary>
    public FileContentResult Cert { get; set; }

    /// <summary>
    /// Расширение файла.
    /// </summary>
    public string Extension { get; set; }
}