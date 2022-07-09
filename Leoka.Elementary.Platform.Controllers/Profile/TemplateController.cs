using Leoka.Elementary.Platform.Base;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Leoka.Elementary.Platform.Controllers.Profile;

/// <summary>
/// Контроллер работы с шаблонами уроков.
/// </summary>
// [AuthFilter]
[ApiController, Route("template")]
public class TemplateController : BaseController
{
    private readonly ITemplateService _templateService;
    
    public TemplateController(ITemplateService templateService)
    {
        _templateService = templateService;
    }

    /// <summary>
    /// Метод формирует шаблон урока конкретного типа.
    /// </summary>
    /// <param name="templateType">Тип шаблона.</param>
    /// <returns>Шаблон урока xml.</returns>
    [HttpGet]
    [Route("generate")]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<string> CreateTemplateAsync([FromQuery] string templateType)
    {
        var result = await _templateService.CreateTemplateAsync(templateType);

        return result;
    }

    /// <summary>
    /// Метод получает список названий шаблонов в зависимости от переданного типа шаблона.
    /// </summary>
    /// <returns>Список названий шаблонов</returns>
    [HttpGet]
    [Route("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<string>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<string>> GetTemplateNamesByTypeAsync([FromQuery] string templateType)
    {
        var result = await _templateService.GetTemplateNamesByTypeAsync(templateType);

        return result;
    }
}