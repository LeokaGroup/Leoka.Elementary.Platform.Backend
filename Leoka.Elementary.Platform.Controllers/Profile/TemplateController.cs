using Leoka.Elementary.Platform.Base;
using Leoka.Elementary.Platform.Core.Filters;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions;
using Leoka.Elementary.Platform.Models.Template.Input;
using Leoka.Elementary.Platform.Models.Template.Output;
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
    /// Метод получает шаблон урока.
    /// </summary>
    /// <param name="templateId">Id шаблона.</param>
    /// <returns>Шаблон урока.</returns>
    [HttpGet]
    [Route("template")]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<TemplateOutput> GetTemplateAsync([FromQuery] long templateId)
    {
        var result = await _templateService.GetTemplateAsync(templateId);

        return result;
    }

    /// <summary>
    /// Метод получает список названий шаблонов в зависимости от переданного типа шаблона.
    /// <param name="idItemTemplate">Id предмета, шаблоны которого нужно получить.</param>
    /// </summary>
    /// <returns>Список названий шаблонов</returns>
    [HttpGet]
    [Route("item-templates")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<string>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<TemplateOutput>> GetTemplateNamesByTypeAsync([FromQuery] long idItemTemplate)
    {
        var result = await _templateService.GetTemplateNamesByTypeAsync(idItemTemplate);

        return result;
    }

    /// <summary>
    /// Метод получает список шаблонов уроков.
    /// </summary>
    /// <returns>Список шаблонов уроков.</returns>
    [HttpGet]
    [Route("items")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<TemplateOutput>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<TemplateOutput>> GetItemTemplatesAsync()
    {
        var result = await _templateService.GetItemTemplatesAsync();

        return result;
    }

    /// <summary>
    /// Метод сохраняет шаблон урока.
    /// </summary>
    /// <param name="templateInput">Входная модель.</param>
    [HttpPatch]
    [Route("template")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task SaveTemplateAsync([FromBody] TemplateInput templateInput)
    {
        await _templateService.SaveTemplateAsync(templateInput.TemplateId, templateInput.Template, GetUserName());
    }
}