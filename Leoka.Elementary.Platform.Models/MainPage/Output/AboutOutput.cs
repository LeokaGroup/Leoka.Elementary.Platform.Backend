namespace Leoka.Elementary.Platform.Models.MainPage.Output;

/// <summary>
/// Класс выходно
/// </summary>
public class AboutOutput
{
    /// <summary>
    /// Главный заголовок блока.
    /// </summary>
    public string AboutTitle { get; set; }

    /// <summary>
    /// Подзаголовок блока.
    /// </summary>
    public string AboutSubTitle { get; set; }

    /// <summary>
    /// Заголовок блока ученика.
    /// </summary>
    public string AboutStudentTitle { get; set; }

    /// <summary>
    /// Подзаголовок блока ученика.
    /// </summary>
    public string AboutStudentSubTitle { get; set; }

    /// <summary>
    /// Заголовок блока преподавателя.
    /// </summary>
    public string AboutMentorTitle { get; set; }

    /// <summary>
    /// Подзаголовок блока преподавателя.
    /// </summary>
    public string AboutMentorSubTitle { get; set; }
}