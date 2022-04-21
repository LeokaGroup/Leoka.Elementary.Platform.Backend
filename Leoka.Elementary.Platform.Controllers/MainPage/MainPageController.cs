﻿using Leoka.Elementary.Platform.Abstractions.MainPage;
using Leoka.Elementary.Platform.Base;
using Leoka.Elementary.Platform.Models.Common.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leoka.Elementary.Platform.Controllers.MainPage;

/// <summary>
/// Контроллер для работы с пользователями.
/// </summary>
[ApiController, Route("main")]
public class MainPageController : BaseController
{
    private readonly IMainPageService _mainPageService;
    
    public MainPageController(IMainPageService mainPageService)
    {
        _mainPageService = mainPageService;
    }

    /// <summary>
    /// Метод получит список элементов хидера.
    /// </summary>
    /// <returns>Список элементов хидера.</returns>
    [AllowAnonymous]
    [HttpGet]
    [Route("header")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<HeaderOutput>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]        
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<HeaderOutput>> GetHeaderItemsAsync()
    {
        var result = await _mainPageService.GetHeaderItemsAsync();

        return result;
    }

    /// <summary>
    /// Метод получит список элементов футера.
    /// </summary>
    /// <returns>Список элементов футера.</returns>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<FooterOutput>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<FooterOutput>> GetFooterItemsAsync()
    {
        var result = await _mainPageService.GetFooterItemsAsync();

        return result;
    }
}