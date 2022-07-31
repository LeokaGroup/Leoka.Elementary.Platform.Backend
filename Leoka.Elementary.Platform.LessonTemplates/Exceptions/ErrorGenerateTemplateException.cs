namespace Leoka.Elementary.Platform.LessonTemplates.Exceptions;

/// <summary>
/// Исключение возникает, если произошла ошибка при формировании шаблона.
/// </summary>
public class ErrorGenerateTemplateException : Exception
{
    public ErrorGenerateTemplateException(string templateType) : base($"Не удалось сформировать шаблон для типа: {templateType}!")
    {
    }
}