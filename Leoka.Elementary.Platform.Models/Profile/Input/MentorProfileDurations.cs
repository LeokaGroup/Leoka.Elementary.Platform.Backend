namespace Leoka.Elementary.Platform.Models.Profile.Input;

/// <summary>
/// Класс описывает список длительностей преподавателя.
/// </summary>
public class MentorProfileDurations
{
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
    public string FullDuration => Time + " " + Unit;
}