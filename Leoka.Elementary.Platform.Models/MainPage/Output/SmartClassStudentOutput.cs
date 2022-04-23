namespace Leoka.Elementary.Platform.Models.MainPage.Output;

/// <summary>
/// Класс выодной модели блока умного класса.
/// </summary>
public class SmartClassStudentOutput
{
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
    /// Список элементов блока.
    /// </summary>
    public List<SmartClassStudentItemsOutput> SmartClassStudentItems { get; set; }
}