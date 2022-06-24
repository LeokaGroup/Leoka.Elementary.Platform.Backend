namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели пола преподавателя.
/// </summary>
public class MentorGenderOutput
{
    /// <summary>
    /// PK.
    /// </summary>
    public int GenderId { get; set; }

    /// <summary>
    /// Пол преподавателя.
    /// </summary>
    public char GenderName { get; set; }
}