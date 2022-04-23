namespace Leoka.Elementary.Platform.Models.MainPage.Output;

public class BestVariantItemsOutput
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
    /// Текст вопроса.
    /// </summary>
    public string VariantText { get; set; }
}