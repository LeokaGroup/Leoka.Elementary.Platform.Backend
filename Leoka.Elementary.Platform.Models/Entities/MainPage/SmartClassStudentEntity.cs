namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей умного класса для главной страницы ученика dbo.SmartClassStudent.
/// </summary>
public class SmartClassStudentEntity
{
    public SmartClassStudentEntity()
    {
        SmartClassStudentItems = new HashSet<SmartClassStudentItemEntity>();
    }

    /// <summary>
    /// PK.
    /// </summary>
    public int SmartClassId { get; set; }

    /// <summary>
    /// Заголовок.
    /// </summary>
    public string SmartClassTitle { get; set; }

    /// <summary>
    /// Подзаголовок.
    /// </summary>
    public string SmartClassSubTitle { get; set; }

    /// <summary>
    /// Url превью.
    /// </summary>
    public string SmartClassUrlPreview { get; set; }

    /// <summary>
    /// Id блока превью.
    /// </summary>
    public int SmartClassItemId { get; set; }

    public HashSet<SmartClassStudentItemEntity> SmartClassStudentItems { get; set; }
}