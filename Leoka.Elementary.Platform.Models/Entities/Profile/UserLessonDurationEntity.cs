namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей длительностей урока преподавателя Profile.UserLessonDurations.
/// </summary>
public class UserLessonDurationEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long DurationId { get; set; }

    /// <summary>
    /// Длительность урока.
    /// </summary>
    public int Time { get; set; }

    /// <summary>
    /// В чем измеряется.
    /// </summary>
    public string Unit { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
}