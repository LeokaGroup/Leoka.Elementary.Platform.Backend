namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей списка предметов Profile.ProfileItems.
/// </summary>
public class ProfileItemEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int ProfileItemId { get; set; }

    /// <summary>
    /// Название предмета.
    /// </summary>
    public string ItemName { get; set; }

    /// <summary>
    /// Системное название предмета.
    /// </summary>
    public string ItemSysName { get; set; }

    /// <summary>
    /// Номер позиции.
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// Номер предмета.
    /// </summary>
    public int ItemNumber { get; set; }
}