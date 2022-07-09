using Leoka.Elementary.Platform.LessonTemplates.Abstractions;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions.Base;

namespace Leoka.Elementary.Platform.LessonTemplates.Services;

/// <summary>
/// Класс реализует методы сервиса создания шаблонов урока.
/// </summary>
public class TemplateService: ITemplateService
{
    /// <summary>
    /// Метод создает экземпляр нужного нам шаблона фабрики.
    /// </summary>
    /// <param name="templateType">Тип шаблрона, который нужно создать.</param>
    /// <returns>Шаблон урока.</returns>
    public async Task<LessonTemplate> CreateTemplateAsync(string templateType)
    {
        //Leoka.Elementary.Platform.LessonTemplates.Abstractions.Humanitarian.English.EnglishTemplate_1, Leoka.Elementary.Platform.LessonTemplates
        var type = Type.GetType(templateType);

        // TODO: не удалось определить тип шаблона.
        if (type is null)
        {
            return null;
        }
        
        var instantiatedObject = Activator.CreateInstance(type);
        var template = instantiatedObject as LessonTemplateFactory;
        
        // TODO: не удалось сформировать шаблон.
        if (template is null)
        {
            return null;
        }
        
        var result = template.CreateTemplateFactoryMethod();

        return await Task.FromResult(result);
    }
}