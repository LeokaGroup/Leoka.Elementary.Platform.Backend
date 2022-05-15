namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей с информацией о профиле преподавателя Profile.MentorProfileInfo.
/// </summary>
public class MentorProfileInfoEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long UserProfileInfoId { get; set; }

    /// <summary>
    /// Аватар профиля пользователя.
    /// </summary>
    public string ProfileIconUrl { get; set; }

    /// <summary>
    /// Полное имя пользователя (ФИО).
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Видны ли контакты всем.
    /// </summary>
    public bool IsVisibleAllContact { get; set; }

    /// <summary>
    /// Номер телефона пользователя.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Email пользователя.
    /// </summary>
    public string Email { get; set; }
}