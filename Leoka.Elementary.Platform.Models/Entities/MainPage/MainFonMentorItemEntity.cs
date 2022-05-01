namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей элементов для блока преподавателя на главной странице преподавателя dbo.MainFonMentorItems.
/// </summary>
public class MainFonMentorItemEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// Id блока, к которому принадлежит элемент.
    /// </summary>
    public int FonSubTitleId { get; set; }

    /// <summary>
    /// Заголовок.
    /// </summary>
    public string FonSubTitleTextFirst { get; set; }

    /// <summary>
    /// Подзаголовок.
    /// </summary>
    public string FonSubTitleTextSecond { get; set; }

    /// <summary>
    /// Номер позиции.
    /// </summary>
    public int FonSubSecondNumber { get; set; }
}