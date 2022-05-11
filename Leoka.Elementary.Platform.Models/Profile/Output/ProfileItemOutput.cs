namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели списка предметов.
/// </summary>
public class ProfileItemOutput
{
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