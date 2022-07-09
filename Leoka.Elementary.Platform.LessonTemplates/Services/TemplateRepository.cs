using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.LessonTemplates.Services;

/// <summary>
/// Класс реализует методы репозитория шаблонов пользователя.
/// </summary>
public class TemplateRepository : ITemplateRepository
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
    /// </summary>
    /// <returns>Список названий шаблонов</returns>
    public async Task<IEnumerable<string>> GetTemplateNamesByTypeAsync(string searchParam)
    {
        try
        {
            var result = await _dbContext.LessonTemplates
                .Where(t => t.TemplateType.Contains(searchParam))
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
}