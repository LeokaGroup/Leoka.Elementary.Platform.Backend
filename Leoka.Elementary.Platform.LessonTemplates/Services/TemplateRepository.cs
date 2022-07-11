using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions;
using Leoka.Elementary.Platform.Models.Template.Output;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.LessonTemplates.Services;

/// <summary>
/// Класс реализует методы репозитория шаблонов пользователя.
/// </summary>
public sealed class TemplateRepository : ITemplateRepository
{
    private readonly PostgreDbContext _dbContext;
    
    public TemplateRepository(PostgreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Метод получает расположение шаблона по его типу.
    /// </summary>
    /// <param name="templateType">Тип шаблона.</param>
    /// <returns>Расположение шаблона.</returns>
    public async Task<string> GetTemplatePatternNamespaceAsync(string templateType)
    {
        try
        {
            var result = await _dbContext.LessonTemplates
                .Where(t => t.TemplateType.Equals(templateType))
                .Select(t => t.PatternNamespace)
                .FirstOrDefaultAsync();

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получает список названий шаблонов в зависимости от переданного типа шаблона.
    /// <param name="idItemTemplate">Id предмета, шаблоны которого нужно получить.</param>
    /// </summary>
    /// <returns>Список названий шаблонов</returns>
    public async Task<IEnumerable<string>> GetTemplateNamesByTypeAsync(long idItemTemplate)
    {
        try
        {
            var result = await _dbContext.LessonTemplates
                .Where(t => t.TemplateItemId == idItemTemplate)
                .Select(t => t.TemplateType)
                .ToListAsync();

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получает список шаблонов уроков.
    /// </summary>
    /// <returns>Список шаблонов уроков.</returns>
    public async Task<IEnumerable<TemplateOutput>> GetItemTemplatesAsync()
    {
        try
        {
            var result = await (from lt in _dbContext.LessonTemplates
                    join pi in _dbContext.ProfileItems
                        on lt.TemplateItemId
                        equals pi.ProfileItemId
                    select new TemplateOutput
                    {
                        ItemName = pi.ItemName,
                        TemplateItemId = pi.ProfileItemId
                    })
                .ToListAsync();

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}