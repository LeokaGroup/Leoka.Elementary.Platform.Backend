﻿using Leoka.Elementary.Platform.Abstractions.Profile;
using Leoka.Elementary.Platform.Base;
using Leoka.Elementary.Platform.Models.Profile.Input;
using Leoka.Elementary.Platform.Models.Profile.Output;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leoka.Elementary.Platform.Controllers.Profile;

/// <summary>
/// Контроллер работы с профилем пользователя.
/// </summary>
[ApiController, Route("profile")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ProfileController : BaseController
{
    private readonly IProfileService _profileService;
    
    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    /// <summary>
    /// Метод получит информацию для профиля пользователя при входе после регитсрации.
    /// </summary>
    /// <returns>Данные о профиле.</returns>
    [HttpGet]
    [Route("info")]
    [ProducesResponseType(200, Type = typeof(ProfileInfoOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<ProfileInfoOutput> GetProfileInfoAsync()
    {
        var result = await _profileService.GetProfileInfoAsync();

        return result;
    }

    /// <summary>
    /// Метод получит список элементов для меню профиля пользователя.
    /// </summary>
    /// <returns>Список элементов меню.</returns>
    [HttpGet]
    [Route("menu")]
    [ProducesResponseType(200, Type = typeof(ProfileMenuItemResult))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<ProfileMenuItemResult> GetProfileMenuItemsAsync()
    {
        var result = await _profileService.GetProfileMenuItemsAsync(GetUserName());

        return result;
    }

    /// <summary>
    /// Метод получит список предметов для выпадающего списка.
    /// </summary>
    /// <returns>Список предметов.</returns>
    [HttpGet]
    [Route("items")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ProfileItemOutput>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<ProfileItemOutput>> GetProfileItemsAsync()
    {
        var result = await _profileService.GetProfileItemsAsync();

        return result;
    }

    /// <summary>
    /// Метод получит список для выпадающего списка длительностей уроков.
    /// </summary>
    /// <returns>Список для выпадающего списка длительностей уроков.</returns>
    [HttpGet]
    [Route("durations")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<LessonDurationOutput>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<LessonDurationOutput>> GetLessonsDurationAsync()
    {
        var result = await _profileService.GetLessonsDurationAsync();

        return result;
    }

    /// <summary>
    /// Метод получит список целей подготовки.
    /// </summary>
    /// <returns>Список целей подготовки.</returns>
    [HttpGet]
    [Route("purposes")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<PurposeTrainingOutput>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<PurposeTrainingOutput>> GetPurposeTrainingsAsync()
    {
        var result = await _profileService.GetPurposeTrainingsAsync();

        return result;
    }

    /// <summary>
    /// Метод сохранит данные анкеты пользователя.
    /// </summary>
    /// <param name="mentorProfileInfoInput">Входная модель.</param>
    /// <returns>Выходная модель с изменениями.</returns>
    [HttpPost]
    [Route("profile-info")]
    [ProducesResponseType(200, Type = typeof(MentorProfileInfoOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<MentorProfileInfoOutput> SaveProfileUserInfoAsync([FromBody] MentorProfileInfoInput mentorProfileInfoInput, [FromForm] IFormCollection mentorCertificates)
    {
        var result = await _profileService.SaveProfileUserInfoAsync(mentorProfileInfoInput, mentorCertificates, GetUserName());

        return result;
    }
    
    /// <summary>
    /// Метод получит дни недели.
    /// </summary>
    /// <returns>Список дней недели.</returns>
    [HttpGet]
    [Route("days-week")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<DayWeekOutput>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<DayWeekOutput>> GetDaysWeekAsync()
    {
        var result = await _profileService.GetDaysWeekAsync();

        return result;
    }
}