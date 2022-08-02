using Leoka.Elementary.Platform.Models.Entities.Template;
using Leoka.Elementary.Platform.Models.Template.Output;

namespace Leoka.Elementary.Platform.LessonTemplates.Abstractions;

/// <summary>
/// Абстракция шаблонов пользователя.
/// </summary>
public interface ITemplateRepository
{
    /// <summary>
    /// Метод получает шаблон по его Id.
    /// </summary>
    /// <param name="templateId">Id шаблона.</param>
    /// <returns>Шаблон урока.</returns>
    Task<TemplateOutput> GetTemplateAsync(long templateId);
    
    /// <summary>
    /// Метод получает список названий шаблонов в зависимости от переданного типа шаблона.
    /// <param name="idItemTemplate">Id предмета, шаблоны которого нужно получить.</param>
    /// </summary>
    /// <returns>Список названий шаблонов</returns>
    Task<IEnumerable<TemplateOutput>> GetTemplateNamesByTypeAsync(long idItemTemplate);
    
    /// <summary>
    /// Метод получает список шаблонов уроков.
    /// </summary>
    /// <returns>Список шаблонов уроков.</returns>
    Task<IEnumerable<TemplateOutput>> GetItemTemplatesAsync();

    /// <summary>
    /// Метод получает шаблон урока, если он был добавлен ранее преподавателем.
    /// </summary>
    /// <param name="templateId">Id шаблона.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные шаблона.</returns>
    Task<LessonUserTemplateEntity> GetUserTemplateByTemplateIdAsync(long templateId, long userId);
    
    /// <summary>
    /// Метод изменяет шаблон урока преподавателя.
    /// </summary>
    /// <param name="templateId">Id шаблона.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="template">Шаблон (json).</param>
    Task AddTemplateAsync(long templateId, long userId, string template);

    /// <summary>
    /// Метод изменяет шаблон преподавателя.
    /// </summary>
    /// <param name="template">Шаблон (json).</param>
    Task ChangeTemplateAsync(LessonUserTemplateEntity template);
}