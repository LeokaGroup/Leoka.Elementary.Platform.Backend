﻿namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей свободного времени преподавателя.
/// </summary>
public class MentorTimeEntity
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
    /// День недели.
    /// </summary>
    public string Day { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
}