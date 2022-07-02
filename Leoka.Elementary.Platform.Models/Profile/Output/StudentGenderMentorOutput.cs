namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели выбранного пола преподавателя.
/// </summary>
public class StudentGenderMentorOutput
{
    /// <summary>
    /// PK.
    /// </summary>
    public int StudentGenderMentorId { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Данные о поле преподавателя.
    /// </summary>
    public MentorGenderOutput MentorGender { get; set; }
}