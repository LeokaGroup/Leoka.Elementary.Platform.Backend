namespace Leoka.Elementary.Platform.Models.Profile.Shared;

/// <summary>
/// Класс модели списка предметов.
/// </summary>
public class ProfileItem
{
    public int ItemId { get; set; }
    
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