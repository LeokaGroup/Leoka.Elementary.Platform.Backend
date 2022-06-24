namespace Leoka.Elementary.Platform.Models.Profile.Input;

/// <summary>
/// Класс описывает список опыта преподавателя.
/// </summary>
public class MentorExperience
{
    /// <summary>
    /// Описание опыта преподавателя.
    /// </summary>
    public string ExperienceText { get; set; }
    
    /// <summary>
    /// PK.
    /// </summary>
    public long ExperienceId { get; set; }
}