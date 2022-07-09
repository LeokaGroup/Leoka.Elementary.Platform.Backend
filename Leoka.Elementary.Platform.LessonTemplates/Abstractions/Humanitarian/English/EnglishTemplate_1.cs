using Leoka.Elementary.Platform.LessonTemplates.Abstractions.Base;
using Leoka.Elementary.Platform.LessonTemplates.Models.Shared.English;

namespace Leoka.Elementary.Platform.LessonTemplates.Abstractions.Humanitarian.English;

/// <summary>
/// Фабрика создает шаблоны английского.
/// </summary>
public class EnglishTemplate_1 : LessonTemplateFactory
{
    /// <summary>
    /// Метод получает конкретный шаблон_1 структуры английского.
    /// </summary>
    /// <returns>Экземпляр конкретной структуры шаблона.</returns>
    public override LessonTemplate CreateTemplateFactoryMethod()
    {
        return new GetEnglishTemplate_1();
    }
}