namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей цен пользователя Profile.UserLessonPrices.
/// </summary>
public class UserLessonPriceEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long PriceId { get; set; }

    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// В чем измеряется.
    /// </summary>
    public string Unit { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
}