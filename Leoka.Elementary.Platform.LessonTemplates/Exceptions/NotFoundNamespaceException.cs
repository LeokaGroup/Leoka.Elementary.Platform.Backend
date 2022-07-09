namespace Leoka.Elementary.Platform.LessonTemplates.Exceptions;

/// <summary>
/// Исключение возникает, если в системе не найдено расположение шаблона.
/// </summary>
public class NotFoundNamespaceException : Exception
{
    public NotFoundNamespaceException(string templateType) : base($"Расположение для шаблона: {templateType} не найдено в системе!")
    {
    }
}