namespace Leoka.Elementary.Platform.Models.Profile.Input;

/// <summary>
/// Класс описывает информацию о преподавателе.
/// </summary>
public class MentorAboutInfo
{
    /// <summary>
    /// Описание информации о преподавателе.
    /// </summary>
    public string AboutInfoText { get; set; }
    
    /// <summary>
    /// PK.
    /// </summary>
    public long AboutInfoId { get; set; }
}