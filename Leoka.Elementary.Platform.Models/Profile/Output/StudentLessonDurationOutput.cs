namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели длительностей студента.
/// </summary>
public class StudentLessonDurationOutput
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
    
    /// <summary>
    /// Полная длительность.
    /// </summary>
    public string FullTime => string.Concat(Time + " " + Unit);
}