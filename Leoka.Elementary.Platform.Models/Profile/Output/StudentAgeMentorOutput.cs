namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели выбранного возраста преподавателя студентом.
/// </summary>
public class StudentAgeMentorOutput
{
    /// <summary>
    /// PK.
    /// </summary>
    public int StudentAgeMentorId { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }

    public MentorAgeOutput MentorAge { get; set; }
}