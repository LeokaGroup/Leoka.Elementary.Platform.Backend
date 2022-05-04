namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели информации о профиле пользователе.
/// </summary>
public class ProfileInfoOutput
{
    /// <summary>
    /// Заголовок.
    /// </summary>
    public string ProfileInfoTitle { get; set; }

    /// <summary>
    /// Текст.
    /// </summary>
    public string ProfileInfoText { get; set; }

    /// <summary>
    /// Отображать ли информацию.
    /// </summary>
    public bool IsVisibleInfo { get; set; }
}