namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели длительностей уроков.
/// </summary>
public class LessonDurationOutput
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

    /// <summary>
    /// Полная длительность.
    /// </summary>
    public string FullTime => string.Concat(Time + " " + Unit);
}