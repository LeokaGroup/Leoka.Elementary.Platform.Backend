namespace Leoka.Elementary.Platform.LessonTemplates.Abstractions.Base;

/// <summary>
/// Фабрика для создания шаблона урока.
/// </summary>
public abstract class LessonTemplateFactory
{
    /// <summary>
    /// Фабричный метод создает шаблон нужного урока.
    /// </summary>
    /// <returns>Шаблон урока.</returns>
    public abstract LessonTemplate CreateTemplateFactoryMethod();
}