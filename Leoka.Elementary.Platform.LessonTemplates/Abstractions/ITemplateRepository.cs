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
    
    /// <summary>
    /// Метод получает список названий шаблонов в зависимости от переданного типа шаблона.
    /// </summary>
    /// <returns>Список названий шаблонов</returns>
    Task<IEnumerable<string>> GetTemplateNamesByTypeAsync(string searchParam);
}