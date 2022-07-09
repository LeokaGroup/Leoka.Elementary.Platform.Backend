namespace Leoka.Elementary.Platform.LessonTemplates.Exceptions;

/// <summary>
/// Исключение возникает, если не удалось определить тип шаблона.
/// </summary>
public class UnknownTemplateTypeException : Exception
{
    public UnknownTemplateTypeException(string templateType) : base($"Не удалось определить тип шаблона: {templateType}!")
    {
    }
}