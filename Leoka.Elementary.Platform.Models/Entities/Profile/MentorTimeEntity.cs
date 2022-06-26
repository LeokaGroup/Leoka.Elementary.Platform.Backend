namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей свободного времени пользователя Profile.UserTimes.
/// </summary>
public class UserTimeEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long TimeId { get; set; }

    /// <summary>
    /// Время начала.
    /// </summary>
    public TimeSpan TimeStart { get; set; }
    
    /// <summary>
    /// Время окончания.
    /// </summary>
    public TimeSpan TimeEnd { get; set; }

    /// <summary>
    /// Id дня.
    /// </summary>
    public int DayId { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
}