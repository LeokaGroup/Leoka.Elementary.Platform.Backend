namespace Leoka.Elementary.Platform.Models.Template.Output;

/// <summary>
/// Класс выходной модели шаблонов уроков.
/// </summary>
public class TemplateOutput
{
    /// <summary>
    /// Название предмета.
    /// </summary>
    public string ItemName { get; set; }

    /// <summary>
    /// Id предмета.
    /// </summary>
    public long TemplateItemId { get; set; }

    /// <summary>
    /// Xml-шаблон.
    /// </summary>
    public string Template { get; set; }

    /// <summary>
    /// Название шаблона.
    /// </summary>
    public string TemplateName { get; set; }

    /// <summary>
    /// Id шаблона.
    /// </summary>
    public long TemplateId { get; set; }

    /// <summary>
    /// Местоположение шаблона.
    /// </summary>
    public string PatternNamespace { get; set; }

    /// <summary>
    /// Тип шаблона.
    /// </summary>
    public string TemplateType { get; set; }
}