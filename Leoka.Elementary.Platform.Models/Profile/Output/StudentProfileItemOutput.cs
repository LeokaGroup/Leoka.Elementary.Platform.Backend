namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели списка предметов студента.
/// </summary>
public class StudentProfileItemOutput
{
    /// <summary>
    /// PK.
    /// </summary>
    public long ItemId { get; set; }

    /// <summary>
    /// Позиция предмета в списке.
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Номер предмета из таблицы Profile.ProfileItems.
    /// </summary>
    public int ItemNumber { get; set; }
}