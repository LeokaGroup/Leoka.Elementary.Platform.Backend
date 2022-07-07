using Leoka.Elementary.Platform.LessonTemplates.Abstractions.Humanitarian.English;

namespace Leoka.Elementary.Platform.LessonTemplates.Abstractions.Base;

/// <summary>
/// Базовая фабрика фабрик для создания шаблона урока.
/// </summary>
public abstract class LessonTemplateFactory
{
    /// <summary>
    /// Метод создает шаблон английского.
    /// </summary>
    /// <returns>Экземпляр класса шаблона.</returns>
    public abstract EnglishTemplateFactory CreateEnglishTemplate();
}