namespace Leoka.Elementary.Platform.Models.MainPage.Output;

/// <summary>
/// Класс выходной модели с данными для блока вопросов.
/// </summary>
public class OptionOutput
{
    /// <summary>
    /// Заголовок блока.
    /// </summary>
    public string BestOptionTitle { get; set; }

    /// <summary>
    /// Подзаголовок блока.
    /// </summary>
    public string BestOptionSubTitle { get; set; }

    /// <summary>
    /// Текст кнопки.
    /// </summary>
    public string BestOptionButtonText { get; set; }
}