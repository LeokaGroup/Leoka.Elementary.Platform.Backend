namespace Leoka.Elementary.Platform.LessonTemplates.Abstractions.Base;

/// <summary>
/// Базовая фабрика фабрик для создания шаблона урока.
/// </summary>
public abstract class LessonTemplateFactory
{
    /// <summary>
    /// Фабричный метод создает шаблон нужного урока.
    /// </summary>
    /// <returns>Шаблон урока.</returns>
    public abstract LessonTemplate CreateTemplateFactoryMethod();
}