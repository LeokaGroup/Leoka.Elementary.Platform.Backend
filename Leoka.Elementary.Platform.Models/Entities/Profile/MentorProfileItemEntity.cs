namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей предметов преподавателя Profile.MentorProfileItems.
/// </summary>
public class MentorProfileItemEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long ItemId { get; set; }

    /// <summary>
    /// Позиция.
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
    
    /// <summary>
    /// Номер предмета.
    /// </summary>
    public int ItemNumber { get; set; }
}