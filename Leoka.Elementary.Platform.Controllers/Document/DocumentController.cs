using Leoka.Elementary.Platform.Abstractions.Document;
using Leoka.Elementary.Platform.Base;
using Leoka.Elementary.Platform.Core.Filters;
using Leoka.Elementary.Platform.Models.Profile.Output;
using Microsoft.AspNetCore.Mvc;

namespace Leoka.Elementary.Platform.Controllers.Document;

/// <summary>
/// Контроллер работы с документами.
/// </summary>
[AuthFilter]
[ApiController, Route("document")]
public class DocumentController : BaseController
{
    private readonly IDocumentService _documentService;
    
    public DocumentController(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    /// <summary>
    /// Метод получит список сертификатов для профиля пользователя.
    /// </summary>
    /// <returns>Список сертификатов.</returns>
    [HttpGet]
    [Route("profile/certs")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<FileContentResultOutput>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<FileContentResultOutput>> GetProfileCertsAsync()
    {
        var result = await _documentService.GetProfileCertsAsync(GetUserName());

        return result;
    }
}