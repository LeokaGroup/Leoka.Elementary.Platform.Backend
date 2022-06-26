namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей Profile.StudentLessonDurations.
/// </summary>
public class StudentLessonDurationEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long DurationId { get; set; }

    /// <summary>
    /// Длительность.
    /// </summary>
    public int Time { get; set; }

    /// <summary>
    /// Часы или минуты.
    /// </summary>
    public string Unit { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
}