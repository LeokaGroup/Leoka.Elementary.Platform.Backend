namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели цен студента.
/// </summary>
public class StudentLessonPriceOutput
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
    
    /// <summary>
    /// Полная цена.
    /// </summary>
    public string FullPrice => $"{Price:0,0}" + " " + Unit;
}