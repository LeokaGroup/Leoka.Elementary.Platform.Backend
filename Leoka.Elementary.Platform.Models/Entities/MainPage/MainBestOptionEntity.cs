namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей вопросов dbo.MainBestOptions.
/// </summary>
public class MainBestOptionEntity
{
    public MainBestOptionEntity()
    {
        MainBestQuestions = new HashSet<MainBestQuestionEntity>();
    }

    /// <summary>
    /// PK.
    /// </summary>
    public int BestOptionId { get; set; }

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

    /// <summary>
    /// Id блока.
    /// </summary>
    public int BestOptionBlockId { get; set; }

    public HashSet<MainBestQuestionEntity> MainBestQuestions { get; set; }
}