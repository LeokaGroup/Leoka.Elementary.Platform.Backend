namespace Leoka.Elementary.Platform.Models.MainPage.Output;

/// <summary>
/// Класс выходной модели фона студента.
/// </summary>
public class MainFonStudentOutput
{
    /// <summary>
    /// Заголовок.
    /// </summary>
    public string FonTitle { get; set; }

    /// <summary>
    /// Подзаголовок.
    /// </summary>
    public string FonSubTitle { get; set; }

    /// <summary>
    /// Id подзаголовка.
    /// </summary>
    public int FonSubTitleId { get; set; }

    /// <summary>
    /// Список элементов для подзаголовка фона.
    /// </summary>
    public List<MainFonStudentItemsOutput> MainFonStudentItems { get; set; } = new();
}