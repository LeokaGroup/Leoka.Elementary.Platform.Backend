namespace Leoka.Elementary.Platform.Models.Profile.Input;

/// <summary>
/// Класс описывает свободное время преподавателя.
/// </summary>
public class MentorTimes
{
    /// <summary>
    /// Время начала.
    /// </summary>
    public TimeSpan TimeStart { get; set; }
    
    /// <summary>
    /// Время окончания.
    /// </summary>
    public TimeSpan TimeEnd { get; set; }

    /// <summary>
    /// День недели.
    /// </summary>
    public string Day { get; set; }
}