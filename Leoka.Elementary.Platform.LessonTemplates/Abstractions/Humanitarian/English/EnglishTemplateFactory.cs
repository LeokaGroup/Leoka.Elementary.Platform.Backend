using Leoka.Elementary.Platform.LessonTemplates.Models.Shared.English;

namespace Leoka.Elementary.Platform.LessonTemplates.Abstractions.Humanitarian.English;

/// <summary>
/// Фабрика создает шаблоны английского.
/// </summary>
public abstract class EnglishTemplateFactory
{
    /// <summary>
    /// Метод получает конкретный шаблон_1 структуры английского.
    /// </summary>
    /// <returns>Экземпляр конкретной структуры шаблона.</returns>
    public abstract EnglishTemplate_1 GetTemplate();
}