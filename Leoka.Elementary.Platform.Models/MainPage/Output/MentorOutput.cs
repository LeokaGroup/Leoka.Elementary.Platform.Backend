namespace Leoka.Elementary.Platform.Models.MainPage.Output;

/// <summary>
/// Класс выходной модели для блока преподавателя. 
/// </summary>
public class MentorOutput
{
    /// <summary>
    /// Заголовок.
    /// </summary>
    public string MentorWorkTitle { get; set; }

    /// <summary>
    /// Подзаголовок.
    /// </summary>
    public string MentorWorkSubTitle { get; set; }

    /// <summary>
    /// Текст кнопки.
    /// </summary>
    public string MentorWorkButtonText { get; set; }

    /// <summary>
    /// Url события кнопки.
    /// </summary>
    public string MentorWorkUrl { get; set; }
}