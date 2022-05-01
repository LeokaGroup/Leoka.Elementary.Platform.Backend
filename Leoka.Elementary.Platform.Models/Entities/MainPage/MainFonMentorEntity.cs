namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей dbo.MainFonMentor.
/// </summary>
public class MainFonMentorEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int FonId { get; set; }

    /// <summary>
    /// Заголовок.
    /// </summary>
    public string FonTitle { get; set; }

    /// <summary>
    /// Подзаголовок.
    /// </summary>
    public string FonSubTitle { get; set; }

    /// <summary>
    /// Id 
    /// </summary>
    public int FonSubTitleId { get; set; }
}