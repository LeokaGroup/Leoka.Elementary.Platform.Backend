namespace Leoka.Elementary.Platform.Models.Entities.Common;

/// <summary>
/// Класс сопоставляется с таблицей dbo.Footer.
/// </summary>
public class FooterEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int FooterId { get; set; }

    /// <summary>
    /// Верхний заголовок.
    /// </summary>
    public string FirstFooterTitle { get; set; }

    /// <summary>
    /// Нижний заголовок.
    /// </summary>
    public string LastFooterTitle { get; set; }

    /// <summary>
    /// Номер столбца.
    /// </summary>
    public int FooterColumnNumber { get; set; }

    /// <summary>
    /// Название пункта.
    /// </summary>
    public string FooterItemText { get; set; }

    /// <summary>
    /// Системное название пункта.
    /// </summary>
    public string FooterItemActionSysName { get; set; }

    /// <summary>
    /// Url редиректа пункта.
    /// </summary>
    public string FooterItemUrl { get; set; }

    /// <summary>
    /// Системное название телеграм-события. 
    /// </summary>
    public string FooterTelegramActionSysName { get; set; }

    /// <summary>
    /// Url редиректа телеграма.
    /// </summary>
    public string FooterTelegramUrl { get; set; }

    /// <summary>
    /// Системное название вк-события.
    /// </summary>
    public string FooterVkActionSysName { get; set; }

    /// <summary>
    /// Url редиректа вк.
    /// </summary>
    public string FooterVkUrl { get; set; }

    /// <summary>
    /// Системное название события WhatsApp.
    /// </summary>
    public string FooterWhatsAppActionSysName { get; set; }
    
    /// <summary>
    /// Url редиректа WhatsApp.
    /// </summary>
    public string FooterWhatsAppUrl { get; set; }

    /// <summary>
    /// Номер позиции.
    /// </summary>
    public int FooterItemPosition { get; set; }
}