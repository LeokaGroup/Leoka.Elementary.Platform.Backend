namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей информации о преподавателе Profile.MentorAboutInfo.
/// </summary>
public class MentorAboutInfoEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long AboutInfoId { get; set; }

    /// <summary>
    /// Описание информации о преподавателе.
    /// </summary>
    public string AboutInfoText { get; set; }

    /// <summary>
    /// Позиция.
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
}