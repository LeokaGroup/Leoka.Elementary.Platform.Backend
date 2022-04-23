﻿using Leoka.Elementary.Platform.Abstractions.MainPage;
using Leoka.Elementary.Platform.Base;
using Leoka.Elementary.Platform.Models.Common.Output;
using Leoka.Elementary.Platform.Models.MainPage.Output;
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

    /// <summary>
    /// Метод получит данные для фона студента.
    /// </summary>
    /// <returns>Данные для фона студента.</returns>
    [AllowAnonymous]
    [HttpGet]
    [Route("fon")]
    [ProducesResponseType(200, Type = typeof(MainFonStudentOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<MainFonStudentOutput> GetMainFonStudentAsync()
    {
        var result = await _mainPageService.GetMainFonStudentAsync();

        return result;
    }

    /// <summary>
    /// Метод получит данные записи на урок.
    /// </summary>
    /// <returns>Данные записи на урок.</returns>
    [AllowAnonymous]
    [HttpGet]
    [Route("reception")]
    [ProducesResponseType(200, Type = typeof(ReceptionOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<ReceptionOutput> GetReceptionAsync()
    {
        var result = await _mainPageService.GetReceptionAsync();

        return result;
    }

    /// <summary>
    /// Метод получит данные блока с чего начать.
    /// </summary>
    /// <returns>Данные блока.</returns>
    [AllowAnonymous]
    [HttpGet]
    [Route("begin")]
    [ProducesResponseType(200, Type = typeof(BeginOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<BeginOutput> GetBeginItemsAsync()
    {
        var result = await _mainPageService.GetBeginItemsAsync();

        return result;
    }

    /// <summary>
    /// Метод получит данные для блока умного класса.
    /// </summary>
    /// <returns>Данные для блока.</returns>
    [AllowAnonymous]
    [HttpGet]
    [Route("smart-class")]
    [ProducesResponseType(200, Type = typeof(SmartClassStudentOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<SmartClassStudentOutput> GetSmartClassAsync()
    {
        var result = await _mainPageService.GetSmartClassAsync();

        return result;
    }
}