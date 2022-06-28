namespace Leoka.Elementary.Platform.Models.Profile.Input;

/// <summary>
/// Класс описывает цены пользователя.
/// </summary>
public class UserProfilePrices
{
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
    /// Полная цена.
    /// </summary>
    public string FullPrice => $"{Price:0,0}" + " " + Unit;
}