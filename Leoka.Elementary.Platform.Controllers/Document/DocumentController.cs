using Leoka.Elementary.Platform.Abstractions.Document;
using Leoka.Elementary.Platform.Base;
using Leoka.Elementary.Platform.Core.Filters;
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
}