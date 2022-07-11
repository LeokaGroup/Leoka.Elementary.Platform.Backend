using System.Xml;
using System.Xml.Serialization;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions.Base;
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
    /// <param name="templateType">Тип шаблрона, который нужно создать.</param>
    /// <returns>Шаблон урока xml.</returns>
    public async Task<string> CreateTemplateAsync(string templateType)
    {
        try
        {
            // Если не передали тип шаблона.
            if (string.IsNullOrEmpty(templateType))
            {
                throw new EmptyTemplateTypeException(templateType);
            }
        
            var templateNamespace = await _templateRepository.GetTemplatePatternNamespaceAsync(templateType);
        
            // Если не нашли namespace расположения шаблона.
            if (string.IsNullOrEmpty(templateNamespace))
            {
                throw new NotFoundNamespaceException(templateType);
            }

            // Получаем расположение пространство шаблона по системному имени типа.
            var type = Type.GetType(templateNamespace);
        
            // Если не удалось определить тип шаблона.
            if (type is null)
            {
                throw new UnknownTemplateTypeException(templateNamespace);
            }
        
            // Создаем инстанс от типа.
            var instantiatedObject = Activator.CreateInstance(type);
        
            // Сам шаблон.
            var template = instantiatedObject as LessonTemplateFactory;
        
            // Если не удалось сформировать шаблон для указанного типа шаблона.
            if (template is null)
            {
                throw new ErrorGenerateTemplateException(templateType);
            }
        
            // Сериализуем шаблон в xml для отдачи фронту.
            // Получаем модель шаблона.
            var templateModel = template.CreateTemplateFactoryMethod();
        
            // Получаем тип модели.
            var getTypeTemplate = templateModel.GetType();
        
            // Сериализуем в xml.
            var xmlSerializer = new XmlSerializer(getTypeTemplate);
            await using var sww = new StringWriter();
            var writerSettings = new XmlWriterSettings { Async = true };    
            await using var writer = XmlWriter.Create(sww, writerSettings);
            xmlSerializer.Serialize(writer, templateModel);
            var xml = sww.ToString();

            return xml;
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