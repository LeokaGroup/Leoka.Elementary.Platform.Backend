namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей записи на урок dbo.WriteReception.
/// </summary>
public class WriteReceptionEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int WriteReceptionId { get; set; }

    /// <summary>
    /// Текст блока.
    /// </summary>
    public string WriteReceptionText { get; set; }

    /// <summary>
    /// Текст кнопки.
    /// </summary>
    public string WriteReceptionButtonText { get; set; }

    /// <summary>
    /// Тип роли.
    /// </summary>
    public int TypeRole { get; set; }
}