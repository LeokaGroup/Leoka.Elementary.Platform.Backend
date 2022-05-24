using Microsoft.AspNetCore.Mvc;

namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели получения аватара пользователя.
/// </summary>
public class FileContentAvatarOutput
{
    /// <summary>
    /// Файл аватара.
    /// </summary>
    public FileContentResult Avatar { get; set; }

    /// <summary>
    /// Расширение файла.
    /// </summary>
    public string Extension { get; set; }

    /// <summary>
    /// Флаг отсутствия изображения аватара.
    /// </summary>
    public bool IsNoPhoto { get; set; }

    /// <summary>
    /// Путь к изображению.
    /// </summary>
    public string AvatarUrl { get; set; }
}