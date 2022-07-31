namespace Leoka.Elementary.Platform.Models.Entities.Template;

/// <summary>
/// Класс сопоставляется с таблицей шаблонов пользователя LessonTemplates.LessonUserTemplates.
/// </summary>
public class LessonUserTemplateEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long UserTemplateId { get; set; }

    /// <summary>
    /// Id шаблона из таблицы LessonTemplates.LessonTemplates.
    /// </summary>
    public long TemplateId { get; set; }

    /// <summary>
    /// Заполненный пользователем шаблон в формате xml.
    /// </summary>
    public string Template { get; set; }

    /// <summary>
    /// Id пользователя, который заполнил шаблон. Нужно для фиксации данных в шаблоне пользователя.
    /// </summary>
    public long UserId { get; set; }
}