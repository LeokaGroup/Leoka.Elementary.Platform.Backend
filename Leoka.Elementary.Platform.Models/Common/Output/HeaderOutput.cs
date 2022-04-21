namespace Leoka.Elementary.Platform.Models.Common.Output;

/// <summary>
/// Класс выходной модели получения полей хидера.
/// </summary>
public class HeaderOutput
{
    /// <summary>
    /// Название пункта.
    /// </summary>
    public string HeaderItem { get; set; }

    /// <summary>
    /// Системное название пункта.
    /// </summary>
    public string HeaderActionSysName { get; set; }

    /// <summary>
    /// Url едиректа.
    /// </summary>
    public string HeaderItemUrl { get; set; }

    /// <summary>
    /// Номер позиции.
    /// </summary>
    public int HeaderItemPosition { get; set; }
}