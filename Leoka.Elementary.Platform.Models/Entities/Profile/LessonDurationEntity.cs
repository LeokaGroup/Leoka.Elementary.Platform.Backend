namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей длительностей урока Profile.LessonsDuration.
/// </summary>
public class LessonDurationEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int DurationId { get; set; }

    /// <summary>
    /// Длительность урока.
    /// </summary>
    public int Time { get; set; }

    /// <summary>
    ///  В чем измеряется длительность.
    /// </summary>
    public string Unit { get; set; }
}