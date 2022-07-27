namespace Leoka.Elementary.Platform.LessonTemplates.Exceptions;

/// <summary>
/// Исключение возникает, если не был передан тип шаблона.
/// </summary>
public class EmptyTemplateTypeException : Exception
{
    public EmptyTemplateTypeException(long templateId) : base($"Id шаблона {templateId} не существует!")
    {
    }
}