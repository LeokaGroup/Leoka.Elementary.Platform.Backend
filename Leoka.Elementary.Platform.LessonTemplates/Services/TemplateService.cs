using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
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
    public async Task<TemplateOutput> CreateTemplateAsync(string templateType)
    {
        try
        {
            var result = new TemplateOutput();
            
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
        
            // Если не удалось сформировать шаблон для укаанного типа шаблона.
            if (template is null)
            {
                throw new ErrorGenerateTemplateException(templateType);
            }
        
            // Сериализуем шаблон в xml для отдачи фронту.
            // Получаем модель шаблона.
            // var templateModel = template.CreateTemplateFactoryMethod();
            //
            // // Получаем тип модели.
            // var getTypeTemplate = templateModel.GetType();
            //
            // // Сериализуем в xml.
            // var xmlSerializer = new XmlSerializer(getTypeTemplate);
            // await using var sww = new StringWriter();
            // var writerSettings = new XmlWriterSettings { Async = true };    
            // await using var writer = XmlWriter.Create(sww, writerSettings);
            // xmlSerializer.Serialize(writer, templateModel);
            // result.Template = sww.ToString();
            
            // var filename = "EnglishTemplate_1.xml";
            // var currentDirectory = Directory.GetDirectoryRoot("Leoka.Elementary.Platform.LessonTemplates.XmlTemplates.English");
            // var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

            // var path = Directory.GetCurrentDirectory().ReplaceLineEndings("Leoka.Elementary.Platform.Backend", @"Leoka.Elementary.Platform.LessonTemplates\XmlTemplates\English\EnglishTemplate_1.xml");
            // var path = Directory.GetCurrentDirectory().Split("\\").LastOrDefault().Replace("Leoka.Elementary.Platform.Backend", @"Leoka.Elementary.Platform.LessonTemplates\XmlTemplates\English");
            // var purchaseOrder = XElement.Load(@"Leoka.Elementary.Platform.LessonTemplates\XmlTemplates\English\EnglishTemplate_1.xml");
            // var purchaseOrder = XElement.Load(@"C:\\Users\\repos\\Portfolio\\Leoka.Elementary.Platform.Backend\\Leoka.Elementary.Platform.LessonTemplates\XmlTemplates\English\EnglishTemplate_1.xml");
            // var sb = new StringBuilder();
            // sb.Append(Directory.GetCurrentDirectory().Split(@"\").Take(Directory.GetCurrentDirectory().Split(@"\").Length - 1));
            // sb.Append(@"Leoka.Elementary.Platform.LessonTemplates\XmlTemplates\English\EnglishTemplate_1.xml");
            // var xml = XElement.Load(sb.ToString());
            
            
            var path = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().LastIndexOf(@"\", StringComparison.InvariantCulture));
            var fullPath = string.Concat(path, @"\Leoka.Elementary.Platform.LessonTemplates\XmlTemplates\English\EnglishTemplate_1.xml"); 
            var xml = XElement.Load(fullPath);
            result.Template = xml.ToString();
            
            
            // var xml = sww.ToString();EnglishTemplate_1
//str.Substring(0, str.Length - len);
    //         result.Template = @"<Contacts>
    //     <Contact>
    //         <input Value=""test value""><text>Enter email address here</text></input>
    //         <Phone Type=""home"">206-555-0144</Phone>
    //         <Phone Type=""work"">425-555-0145</Phone>
    //         <Address>
    //         <Street1>123 Main St</Street1>
    //         <City>Mercer Island</City>
    //         <State>WA</State>
    //         <Postal>68042</Postal>
    //         </Address>
    //         <NetWorth>10</NetWorth>
    //     </Contact>
    //     <Contact>
    //         <Name>Gretchen Rivas</Name>
    //         <Phone Type=""mobile"">206-555-0163</Phone>
    //         <Address>
    //         <Street1>123 Main St</Street1>
    //         <City>Mercer Island</City>
    //         <State>WA</State>
    //         <Postal>68042</Postal>
    //         </Address>
    //         <NetWorth>11</NetWorth>
    //     </Contact>
    // </Contacts>";

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