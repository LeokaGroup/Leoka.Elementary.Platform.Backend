namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей Profile.StudentGenderMentor.
/// </summary>
public class StudentGenderMentorEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int StudentGenderMentorId { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }

    public MentorGenderEntity MentorGender { get; set; }
}