namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели дней недели.
/// </summary>
public class DayWeekOutput
{
    /// <summary>
    /// День недели.
    /// </summary>
    public string DayName { get; set; }

    /// <summary>
    /// Системное название дня недели.
    /// </summary>
    public string DaySysName { get; set; }

    /// <summary>
    /// Позиция.
    /// </summary>
    public int Position { get; set; }
}