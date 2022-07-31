using Leoka.Elementary.Platform.Models.Template.Output;

namespace Leoka.Elementary.Platform.LessonTemplates.Abstractions;

/// <summary>
/// Абстракция сервиса создания шаблонов урока.
/// </summary>
public interface ITemplateService
{
    /// <summary>
    /// Метод получает шаблон урока.
    /// </summary>
    /// <param name="templateId">Id шаблона, который нужно создать.</param>
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
}