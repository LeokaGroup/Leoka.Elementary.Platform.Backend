namespace Leoka.Elementary.Platform.Models.MainPage.Output;

/// <summary>
/// Класс выходной модели со списком вариантов для вопросов.
/// </summary>
public class BestQuestionVariantItemsOutput
{
    /// <summary>
    /// PK.
    /// </summary>
    public int MainBestQuestionVariantId { get; set; }

    /// <summary>
    /// Id вопроса.
    /// </summary>
    public int QuestionId { get; set; }

    /// <summary>
    /// Текст варианта вопроса.
    /// </summary>
    public string VariantText { get; set; }
}