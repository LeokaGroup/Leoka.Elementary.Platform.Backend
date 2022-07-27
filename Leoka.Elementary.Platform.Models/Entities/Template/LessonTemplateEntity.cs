namespace Leoka.Elementary.Platform.Models.Entities.Template;

/// <summary>
/// Класс сопоставляется с таблицей шаблонов уроков LessonTemplates.LessonTemplates.
/// </summary>
public class LessonTemplateEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long TemplateId { get; set; }

    /// <summary>
    /// Id предмета из таблицы Profile.ProfileItems.
    /// </summary>
    public long TemplateItemId { get; set; }

    /// <summary>
    /// Шаблон в формате xml.
    /// </summary>
    public string Template { get; set; }

    /// <summary>
    /// Пространство имен паттерна.
    /// </summary>
    public string PatternNamespace { get; set; }

    /// <summary>
    /// Тип шаблона.
    /// </summary>
    public string TemplateType { get; set; }

    /// <summary>
    /// Название шаблона.
    /// </summary>
    public string TemplateName { get; set; }
}