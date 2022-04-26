namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей работы с преподавателем dbo.MentorWork.
/// </summary>
public class MentorWorkEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int MentorWorkId { get; set; }

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

    /// <summary>
    /// Изображение преподавателя.
    /// </summary>
    public string UrlIconMentor { get; set; }
}