namespace Leoka.Elementary.Platform.LessonTemplates.Exceptions;

/// <summary>
/// Исключение возникает, если не был передан тип шаблона.
/// </summary>
public class EmptyTemplateTypeException : Exception
{
    public EmptyTemplateTypeException(string templateType) : base($"Пустой тип шаблона: {templateType}!")
    {
    }
}