using Leoka.Elementary.Platform.LessonTemplates.Abstractions.Base;

namespace Leoka.Elementary.Platform.LessonTemplates.Abstractions;

/// <summary>
/// Абстракция сервиса создания шаблонов урока.
/// </summary>
public interface ITemplateService
{
    /// <summary>
    /// Метод создает экземпляр нужного нам шаблона фабрики.
    /// </summary>
    /// <param name="templateType">Тип шаблрона, который нужно создать.</param>
    /// <returns>Шаблон урока.</returns>
    Task<LessonTemplate> CreateTemplateAsync(string templateType);
}