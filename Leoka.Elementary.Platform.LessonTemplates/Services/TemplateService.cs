using System.Xml.Linq;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions;
using Leoka.Elementary.Platform.LessonTemplates.Exceptions;
using Leoka.Elementary.Platform.Models.Template.Output;

namespace Leoka.Elementary.Platform.LessonTemplates.Services;

/// <summary>
/// Класс реализует методы сервиса создания шаблонов урока.
/// </summary>
public sealed class TemplateService: ITemplateService
{
    private readonly ITemplateRepository _templateRepository;
    
    public TemplateService(ITemplateRepository templateRepository)
    {
        _templateRepository = templateRepository;
    }

    /// <summary>
    /// Метод создает экземпляр нужного нам шаблона фабрики.
    /// </summary>
    /// <param name="templateId">Тип шаблрона, который нужно создать.</param>
    /// <returns>Шаблон урока xml.</returns>
    public async Task<TemplateOutput> CreateTemplateAsync(long templateId)
    {
        try
        {
            // Если не передали тип шаблона.
            if (templateId <= 0)
            {
                throw new EmptyTemplateTypeException(templateId);
            }
        
            // Получаем нахождение шаблона.
            var result = await _templateRepository.GetTemplatePatternNamespaceAsync(templateId);

            var path = Directory.GetCurrentDirectory()
                .Remove(Directory.GetCurrentDirectory()
                .LastIndexOf(@"\", StringComparison.InvariantCulture));
            var fullPath = path + result.PatternNamespace + result.TemplateType + ".xml";
            var xml = XElement.Load(fullPath);
            result.Template = xml.ToString();

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
    public async Task<IEnumerable<TemplateOutput>> GetTemplateNamesByTypeAsync(long idItemTemplate)
    {
        try
        {
            var result = await _templateRepository.GetTemplateNamesByTypeAsync(idItemTemplate);

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
            var result = await _templateRepository.GetItemTemplatesAsync();

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