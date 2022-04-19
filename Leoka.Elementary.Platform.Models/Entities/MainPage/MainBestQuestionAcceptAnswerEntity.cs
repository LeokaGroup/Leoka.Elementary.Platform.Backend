namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей ответов dbo.MainBestQuestionAcceptAnswers.
/// </summary>
public class MainBestQuestionAcceptAnswerEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int AnswerId { get; set; }

    /// <summary>
    /// Id варианта ответа.
    /// </summary>
    public int QuestionVariantId { get; set; }

    /// <summary>
    /// Выбранный вариант ответа.
    /// </summary>
    public string SelectedAnswer { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }

    public MainBestQuestionOptionEntity MainBestQuestionOption { get; set; }
}