namespace Leoka.Elementary.Platform.Models.Template.Input;

/// <summary>
/// Класс входной модели шаблонов уроков.
/// </summary>
public class TemplateInput
{
    /// <summary>
    /// Id шаблона.
    /// </summary>
    public long TemplateId { get; set; }

    /// <summary>
    /// Шаблон (json).
    /// </summary>
    public string Template { get; set; }
}