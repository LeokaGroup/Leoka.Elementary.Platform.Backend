namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей dbo.главной странице "С чего начать?" dbo.WhereBegin.
/// </summary>
public class WhereBeginEntity
{
    public WhereBeginEntity()
    {
        WhereBeginItems = new HashSet<WhereBeginItemEntity>();
    }

    /// <summary>
    /// PK.
    /// </summary>
    public int WhereBeginId { get; set; }

    /// <summary>
    /// Заголовок.
    /// </summary>
    public string WhereBeginTitle { get; set; }

    /// <summary>
    /// Подзаголовок.
    /// </summary>
    public string WhereBeginSubTitle { get; set; }

    /// <summary>
    /// Id блока.
    /// </summary>
    public int BeginItemId { get; set; }

    /// <summary>
    /// Тип роли.
    /// </summary>
    public int TypeRole { get; set; }
    
    public virtual ICollection<WhereBeginItemEntity> WhereBeginItems { get; set; }
}