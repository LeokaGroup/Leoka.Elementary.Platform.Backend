using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Base;
using Leoka.Elementary.Platform.Models.User.Input;
using Leoka.Elementary.Platform.Models.User.Output;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leoka.Elementary.Platform.Controllers.User;

/// <summary>
/// Контроллер для работы с пользователями.
/// </summary>
[ApiController, Route("user")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UserController : BaseController
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Метод регистрирует пользователя.
    /// </summary>
    /// <param name="createUserInput">Входная модель.</param>
    /// <returns>Данные пользователя.</returns>
    [AllowAnonymous]
    [HttpPost]
    [Route("signup")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403, Type = typeof(UserOutput))]        
    [ProducesResponseType(500)]
    public async Task<UserOutput> CreateUserAsync([FromBody] UserInput createUserInput)
    {
        var result = await _userService.CreateUserAsync(createUserInput.FirstName, createUserInput.UserEmail, createUserInput.PhoneNumber, createUserInput.UserRole, createUserInput.UserPassword);

        return result;
    }
}