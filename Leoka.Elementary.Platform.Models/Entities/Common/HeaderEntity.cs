namespace Leoka.Elementary.Platform.Models.Entities.Common;

/// <summary>
/// Класс сопоставляется с таблицей dbo.Header.
/// </summary>
public class HeaderEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int HeaderId { get; set; }

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