using Leoka.Elementary.Platform.Base;
using Leoka.Elementary.Platform.Core.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Leoka.Elementary.Platform.Controllers.Profile;

/// <summary>
/// Контроллер работы с шаблонами уроков.
/// </summary>
[AuthFilter]
[ApiController, Route("template")]
public class TemplateController : BaseController
{
    public TemplateController()
    {
    }
}