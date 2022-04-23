namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей элементов для блока на главной странице "С чего начать?" dbo.WhereBeginItems.
/// </summary>
public class WhereBeginItemEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// Url.
    /// </summary>
    public string BeginUrlIcon { get; set; }

    /// <summary>
    /// Заголовок.
    /// </summary>
    public string BeginTitle { get; set; }

    /// <summary>
    /// Подзаголовок.
    /// </summary>
    public string BeginSubTitle { get; set; }

    public int BeginItemId { get; set; }

    public virtual WhereBeginEntity WhereBegin { get; set; }
}