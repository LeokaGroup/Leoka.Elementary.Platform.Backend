namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей Profile.StudentAgeMentor.
/// </summary>
public class StudentAgeMentorEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int StudentAgeMentorId { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Id возраста.
    /// </summary>
    public int AgeId { get; set; }

    public MentorAgeEntity MentorAge { get; set; }
}