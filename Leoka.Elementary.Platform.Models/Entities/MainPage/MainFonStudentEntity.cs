namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей dbo.MainFonStudent.
/// </summary>
public class MainFonStudentEntity
{
    public MainFonStudentEntity()
    {
        MainFonStudentItems = new HashSet<MainFonStudentItemEntity>();
    }

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
    /// Id подзаголовка.
    /// </summary>
    public int FonSubTitleId { get; set; }
    
    public HashSet<MainFonStudentItemEntity> MainFonStudentItems { get; set; }
}