using Leoka.Elementary.Platform.Access.Abstraction;
using Leoka.Elementary.Platform.Base;
using Leoka.Elementary.Platform.Models.Role.Output;
using Leoka.Elementary.Platform.Models.User.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leoka.Elementary.Platform.Controllers.Role;

/// <summary>
/// Контроллер по работе с ролями.
/// </summary>
[ApiController, Route("role")]
public class RoleController : BaseController
{
    private readonly IRoleService _roleService;
    
    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("roles")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<RoleOutput>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<RoleOutput>> GetRolesAsync()
    {
        var result = await _roleService.GetRolesAsync();

        return result;
    }
    
    /// <summary>
    /// Метод обновит токен.
    /// </summary>
    /// <returns>Новый токен.</returns>
    [HttpGet, Route("token")]
    [ProducesResponseType(200, Type = typeof(ClaimOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GenerateTokenAsync()
    {
        var result = await _roleService.GenerateTokenAsync(GetUserName());

        return Ok(result);
    }
}