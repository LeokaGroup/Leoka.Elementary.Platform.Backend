namespace Leoka.Elementary.Platform.LessonTemplates.Exceptions;

/// <summary>
/// Исключение возникает, если не передали шаблон.
/// </summary>
public class EmptyTemplateException : Exception
{
    public EmptyTemplateException(string template) : base($"Шаблона {template} не существует!")
    {
    }
}