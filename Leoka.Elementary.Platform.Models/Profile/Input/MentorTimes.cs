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
    /// Название дня.
    /// </summary>
    public string DayName { get; set; }

    /// <summary>
    /// Id дня.
    /// </summary>
    public int DayId { get; set; }
    
    /// <summary>
    /// Системное название дня.
    /// </summary>
    public string DaySysName { get; set; }

    /// <summary>
    /// Id времени.
    /// </summary>
    public long TimeId { get; set; }
}