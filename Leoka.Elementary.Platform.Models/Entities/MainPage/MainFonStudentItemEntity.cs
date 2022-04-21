namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей элементов главного фона dbo.MainFonStudentItems.
/// </summary>
public class MainFonStudentItemEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// Id подзаголовка фона студента.
    /// </summary>
    public int FonSubTitleId { get; set; }

    /// <summary>
    /// Подзаголовок.
    /// </summary>
    public string FonSubTitleText { get; set; }

    public MainFonStudentEntity MainFonStudent { get; set; }
}