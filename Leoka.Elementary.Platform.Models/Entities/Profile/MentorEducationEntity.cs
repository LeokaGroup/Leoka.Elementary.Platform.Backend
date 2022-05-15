namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей образования преподавателя Profile.MentorEducations.
/// </summary>
public class MentorEducationEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long EducationId { get; set; }

    /// <summary>
    /// Описание образования преподавателя.
    /// </summary>
    public string EducationText { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
}