namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей Profile.StudentComments.
/// </summary>
public class StudentCommentEntity
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