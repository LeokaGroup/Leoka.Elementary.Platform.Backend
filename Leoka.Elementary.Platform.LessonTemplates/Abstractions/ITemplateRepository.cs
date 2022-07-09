namespace Leoka.Elementary.Platform.LessonTemplates.Abstractions;

/// <summary>
/// Абстракция шаблонов пользователя.
/// </summary>
public interface ITemplateRepository
{
    /// <summary>
    /// Метод получает расположение шаблона по его типу.
    /// </summary>
    /// <param name="templateType">Тип шаблона.</param>
    /// <returns>Расположение шаблона.</returns>
    Task<string> GetTemplatePatternNamespaceAsync(string templateType);
}