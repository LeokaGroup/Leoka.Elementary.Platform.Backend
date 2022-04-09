﻿using Leoka.Elementary.Platform.Abstractions.User;
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
    [ProducesResponseType(200, Type = typeof(UserOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]        
    [ProducesResponseType(500)]
    public async Task<UserOutput> CreateUserAsync([FromBody] UserInput createUserInput)
    {
        var result = await _userService.CreateUserAsync(createUserInput.FirstName, createUserInput.ContactData, createUserInput.UserRole, createUserInput.UserPassword);

        return result;
    }

    /// <summary>
    /// Метод авторизует пользователя.
    /// </summary>
    /// <param name="userLogin">Email или номер телефона.</param>
    /// <param name="userPassword">Пароль.</param>
    /// <returns>Данные пользователя.</returns>
    [AllowAnonymous]
    [HttpGet]
    [Route("signin")]
    [ProducesResponseType(200, Type = typeof(UserOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    public async Task<ClaimOutput> SignInAsync([FromQuery] string userLogin, string userPassword)
    {
        var result = await _userService.SignInAsync(userLogin, userPassword);

        return result;
    }
}