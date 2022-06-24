namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели комментариев студента.
/// </summary>
public class StudentCommentsOutput
{
    /// <summary>
    /// PK.
    /// </summary>
    public long CommentId { get; set; }

    /// <summary>
    /// Текст комментария.
    /// </summary>
    public string CommentText { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
}