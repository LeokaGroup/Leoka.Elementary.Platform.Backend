namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей Profile.StudentLessonPrices.
/// </summary>
public class StudentLessonPriceEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long PriceId { get; set; }

    /// <summary>
    /// Цена.
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Валюта.
    /// </summary>
    public string Unit { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
}