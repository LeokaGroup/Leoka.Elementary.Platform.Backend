namespace Leoka.Elementary.Platform.Models.Profile.Input;

/// <summary>
/// Класс описывает образование преподавателя.
/// </summary>
public class MentorEducations
{
    /// <summary>
    /// Описание образования преподавателя.
    /// </summary>
    public string EducationText { get; set; }
    
    /// <summary>
    /// PK.
    /// </summary>
    public long EducationId { get; set; }
}