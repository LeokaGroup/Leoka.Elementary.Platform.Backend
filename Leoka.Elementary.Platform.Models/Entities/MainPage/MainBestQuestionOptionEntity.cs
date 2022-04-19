namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей вопросов dbo.MainBestQuestionOptions.
/// </summary>
public class MainBestQuestionOptionEntity
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

    public MainBestQuestionEntity MainBestQuestion { get; set; }
}