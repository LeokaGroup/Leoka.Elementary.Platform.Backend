namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей дней недели Profile.DaysWeek.
/// </summary>
public class DayWeekEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int DayId { get; set; }

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