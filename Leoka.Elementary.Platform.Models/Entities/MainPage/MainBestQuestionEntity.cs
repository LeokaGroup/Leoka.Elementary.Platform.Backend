namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей лучших вопросов dbo.MainBestQuestions.
/// </summary>
public class MainBestQuestionEntity
{
    public MainBestQuestionEntity()
    {
        MainBestOptions = new HashSet<MainBestQuestionOptionEntity>();
    }

    /// <summary>
    /// PK.
    /// </summary>
    public int QuestionId { get; set; }

    public int MainBestOptionBlockId { get; set; }

    public string MainBestOptionQuestionText { get; set; }

    public HashSet<MainBestQuestionOptionEntity> MainBestOptions { get; set; }

    public MainBestOptionEntity MainBestOption { get; set; }
}