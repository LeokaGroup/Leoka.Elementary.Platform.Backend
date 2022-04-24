namespace Leoka.Elementary.Platform.Models.MainPage.Output;

/// <summary>
/// Класс выходной модели сос списком вопросов.
/// </summary>
public class BestQuestionOutput
{
    /// <summary>
    /// PK.
    /// </summary>
    public int QuestionId { get; set; }

    /// <summary>
    /// Id блока.
    /// </summary>
    public int MainBestOptionBlockId { get; set; }

    /// <summary>
    /// Текст вопроса.
    /// </summary>
    public string MainBestOptionQuestionText { get; set; }
    
    /// <summary>
    /// Текст кнопки.
    /// </summary>
    public string ButtonActionText { get; set; }

    /// <summary>
    /// Список вопросов.
    /// </summary>
    public List<BestQuestionVariantItemsOutput> MainBestOptions { get; set; }
}