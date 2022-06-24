namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей Profile.MentorGender.
/// </summary>
public class MentorGenderEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int GenderId { get; set; }

    /// <summary>
    /// Пол преподавателя.
    /// </summary>
    public char GenderName { get; set; }
}