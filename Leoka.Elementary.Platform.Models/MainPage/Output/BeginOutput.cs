namespace Leoka.Elementary.Platform.Models.MainPage.Output;

/// <summary>
/// Класс выходной модели блока с чего начать.
/// </summary>
public class BeginOutput
{
    /// <summary>
    /// Заголовок.
    /// </summary>
    public string WhereBeginTitle { get; set; }

    /// <summary>
    /// Подзаголовок.
    /// </summary>
    public string WhereBeginSubTitle { get; set; }

    /// <summary>
    /// Список элементов блока.
    /// </summary>
    public ICollection<BeginItemsOutput> WhereBeginItems { get; set; }
}