namespace Leoka.Elementary.Platform.Models.Profile.Input;

/// <summary>
/// Класс описывает цены преподавателя.
/// </summary>
public class MentorProfilePrices
{
    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// В чем измеряется.
    /// </summary>
    public string Unit { get; set; }

    /// <summary>
    /// Цена с измерением.
    /// </summary>
    public string FullPrice => Price + " " + Unit;
}