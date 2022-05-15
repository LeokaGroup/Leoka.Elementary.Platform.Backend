namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей опыта преподавателя Profile.MentorExperience.
/// </summary>
public class MentorExperienceEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long ExperienceId { get; set; }

    /// <summary>
    /// Описание опыта преподавателя.
    /// </summary>
    public string ExperienceText { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
}