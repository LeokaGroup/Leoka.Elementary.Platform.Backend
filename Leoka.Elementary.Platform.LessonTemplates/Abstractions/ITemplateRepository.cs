﻿using Leoka.Elementary.Platform.Models.Template.Output;

namespace Leoka.Elementary.Platform.LessonTemplates.Abstractions;

/// <summary>
/// Абстракция шаблонов пользователя.
/// </summary>
public interface ITemplateRepository
{
    /// <summary>
    /// Метод получает расположение шаблона по его типу.
    /// </summary>
    /// <param name="templateId">Id шаблона.</param>
    /// <returns>Расположение шаблона.</returns>
    Task<TemplateOutput> GetTemplatePatternNamespaceAsync(long templateId);
    
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