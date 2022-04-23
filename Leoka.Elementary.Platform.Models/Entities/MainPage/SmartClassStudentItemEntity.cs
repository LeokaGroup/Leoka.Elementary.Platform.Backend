namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей элементов для умного класса студента. dbo.SmartClassStudentItems.
/// </summary>
public class SmartClassStudentItemEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int ItemId { get; set; }

    public int SmartClassItemId { get; set; }

    /// <summary>
    /// Заголовок.
    /// </summary>
    public string SmartItemTitle { get; set; }

    /// <summary>
    /// Подзаголовок.
    /// </summary>
    public string SmartItemSubTitle { get; set; }

    public virtual SmartClassStudentEntity SmartClassStudent { get; set; }
}