namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей информации о профиле при входе в ЛК Profile.ProfileInfos.
/// </summary>
public class ProfileInfoEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int ProfileInfoId { get; set; }

    /// <summary>
    /// Заголовок.
    /// </summary>
    public string ProfileInfoTitle { get; set; }

    /// <summary>
    /// Текст.
    /// </summary>
    public string ProfileInfoText { get; set; }

    /// <summary>
    /// Отображать ли информацию.
    /// </summary>
    public bool IsVisibleInfo { get; set; }
}