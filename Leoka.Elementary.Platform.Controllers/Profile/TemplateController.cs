using Leoka.Elementary.Platform.Base;
using Leoka.Elementary.Platform.Core.Filters;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions.Base;
using Microsoft.AspNetCore.Mvc;

namespace Leoka.Elementary.Platform.Controllers.Profile;

/// <summary>
/// Контроллер работы с шаблонами уроков.
/// </summary>
[AuthFilter]
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
    /// <returns>Шаблон урока.</returns>
    [HttpGet]
    [Route("generate")]
    [ProducesResponseType(200, Type = typeof(LessonTemplate))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<LessonTemplate> CreateTemplateAsync([FromQuery] string templateType)
    {
        var result = await _templateService.CreateTemplateAsync(templateType);

        return result;
    }
}