using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Base;
using Leoka.Elementary.Platform.Core.Filters;
using Leoka.Elementary.Platform.Models.User.Input;
using Leoka.Elementary.Platform.Models.User.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leoka.Elementary.Platform.Controllers.User;

/// <summary>
/// Контроллер для работы с пользователями.
/// </summary>
[ApiController, Route("user")]
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
    [AuthFilter]
    [Route("signup")]
    [ProducesResponseType(200, Type = typeof(UserOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<UserOutput> CreateUserAsync([FromBody] UserInput createUserInput)
    {
        var result = await _userService.CreateUserAsync(createUserInput.FirstName, createUserInput.UserEmail, createUserInput.UserRole, createUserInput.UserPhoneNumber);

        return result;
    }

    /// <summary>
    /// Метод авторизует пользователя.
    /// </summary>
    /// <param name="userLogin">Email или номер телефона.</param>
    /// <param name="userPassword">Пароль.</param>
    [AllowAnonymous]
    [HttpGet]
    [Route("signin")]
    [ProducesResponseType(200, Type = typeof(UserOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task SignInAsync([FromQuery] string userLogin, string userPassword)
    {
        var token = await _userService.SignInAsync(userLogin, userPassword);
        
        HttpContext.Response.Headers.Add("Authorization", "Bearer " + token);
        HttpContext.Response.Cookies.Append("token", token, 
            new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(60)
            });
    }

    /// <summary>
    /// Метод отправит пользователя на страницу успешного подтверждения почты.
    /// </summary>
    /// <returns>Редиректит на страницу успеха.</returns>
    [AllowAnonymous]
    [HttpGet]
    [Route("confirm-email")]
    public async Task<RedirectResult> ConfirmEmailAccountCode([FromQuery] string code)
    {
        var isConfirm = await _userService.ConfirmEmailAccountCode(code);

        // TODO: заменить на получение ссылок из БД.
        return RedirectPermanent(isConfirm ? "https://leoka-elementary.site/user/success-confirm" : "https://leoka-elementary.site/user/fail-confirm");
    }
}