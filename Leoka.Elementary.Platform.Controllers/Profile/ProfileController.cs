using Leoka.Elementary.Platform.Abstractions.Profile;
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
// [AuthFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController, Route("profile")]
public class ProfileController : BaseController
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    /// <summary>
    /// Метод получит информацию для профиля пользователя при входе после регистрации.
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
        var result = await _profileService.GetPurposeTrainingsAsync(GetUserName());

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
    public async Task<MentorProfileInfoOutput> SaveProfileUserInfoAsync([FromForm] string profileData, [FromForm] IFormCollection mentorFiles)
    {
        var result = await _profileService.SaveProfileUserInfoAsync(profileData, mentorFiles, GetUserName());
        
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

    /// <summary>
    /// Метод получит аватар профиля пользователя.
    /// </summary>
    /// <returns>Аватар профиля пользователя.</returns>
    [HttpGet]
    [Route("avatar")]
    [ProducesResponseType(200, Type = typeof(FileContentAvatarOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<FileContentAvatarOutput> GetProfileAvatarAsync()
    {
        var result = await _profileService.GetProfileAvatarAsync(GetUserName());

        return result;
    }

    /// <summary>
    /// Метод получит данные анкеты пользователя.
    /// </summary>
    /// <returns>Данные анкеты пользователя.</returns>
    [Authorize]
    [HttpGet]
    [Route("worksheet")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> GetProfileWorkSheetAsync()
    {
        var result = await _profileService.GetProfileWorkSheetAsync(GetUserName());

        return result;
    }

    /// <summary>
    /// Метод обновит аватар пользователя.
    /// </summary>
    /// <param name="avatar">Новое изображение аватара.</param>
    /// <returns>Новый файл аватара.</returns>
    [HttpPatch]
    [Route("avatar")]
    [ProducesResponseType(200, Type = typeof(FileContentAvatarOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<FileContentAvatarOutput> UpdateAvatarAsync([FromForm] IFormCollection avatar)
    {
        var result = await _profileService.UpdateAvatarAsync(avatar, GetUserName());

        return result;
    }

    /// <summary>
    /// Метод обновит ФИО пользователя.
    /// </summary>
    /// <param name="mentorProfileInfoInput">Входная модель.</param>
    /// <returns>Измененные данные.</returns>
    [HttpPatch]
    [Route("fio")]
    [ProducesResponseType(200, Type = typeof(MentorProfileInfoOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<MentorProfileInfoOutput> UpdateUserFioAsync([FromBody] MentorProfileInfoInput mentorProfileInfoInput)
    {
        var result = await _profileService.UpdateUserFioAsync(mentorProfileInfoInput.FirstName, mentorProfileInfoInput.LastName, mentorProfileInfoInput.SecondName, GetUserName());

        return result;
    }

    /// <summary>
    /// Метод обновит контактные данные пользователя.
    /// </summary>
    /// <param name="mentorProfileInfoInput">Входная модель.</param>
    /// <returns>Измененные данные.</returns>
    [HttpPatch]
    [Route("contacts")]
    [ProducesResponseType(200, Type = typeof(MentorProfileInfoOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<MentorProfileInfoOutput> UpdateUserContactsAsync([FromBody] MentorProfileInfoInput mentorProfileInfoInput)
    {
        var result = await _profileService.UpdateUserContactsAsync(mentorProfileInfoInput.IsVisibleAllContact, mentorProfileInfoInput.PhoneNumber, mentorProfileInfoInput.Email, GetUserName());

        return result;
    }

    /// <summary>
    /// Метод обновит или добавит список предметов в анкете.
    /// </summary>
    /// <param name="worksheetInput">Входная модель.</param>
    /// <returns>Обновленный список предметов.</returns>
    [HttpPatch]
    [Route("items")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> SaveItemsAsync([FromBody] WorksheetInput worksheetInput)
    {
        var result = await _profileService.SaveItemsAsync(worksheetInput.UserItems, GetUserName());

        return result;
    }

    /// <summary>
    /// Метод обновит список цен преподавателя в анкете.
    /// </summary>
    /// <param name="worksheetInput">Входная модель.</param>
    /// <returns>Обновленный список цен.</returns>
    [HttpPatch]
    [Route("user-prices")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> UpdateUserPricesAsync([FromBody] WorksheetInput worksheetInput)
    {
        var result = await _profileService.UpdateUserPricesAsync(worksheetInput.UserPrices, GetUserName());

        return result;
    }

    /// <summary>
    /// Метод обновит список длительностей преподавателя в анкете.
    /// </summary>
    /// <param name="worksheetInput">Входная модель.</param>
    /// <returns>Обновленный список длительностей.</returns>
    [HttpPatch]
    [Route("user-durations")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> UpdateMentorDurationsAsync([FromBody] WorksheetInput worksheetInput)
    {
        var result = await _profileService.UpdateMentorDurationsAsync(worksheetInput.UserDurations, GetUserName());
        
        return result;
    }

    /// <summary>
    /// Метод обновит список времени преподавателя в анкете.
    /// </summary>
    /// <param name="worksheetInput">Входная модель.</param>
    /// <returns>Обновленный список длительностей.</returns>
    [HttpPatch]
    [Route("user-times")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> UpdateUserTimesAsync([FromBody] WorksheetInput worksheetInput)
    {
        var result = await _profileService.UpdateUserTimesAsync(worksheetInput.UserTimes, GetUserName());

        return result;
    }
    
    /// <summary>
    /// Метод обновит данные о себе преподавателя в анкете.
    /// </summary>
    /// <param name="worksheetInput">Входная модель.</param>
    /// <returns>Обновленный данные о себе.</returns>
    [HttpPatch]
    [Route("mentor-about")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> UpdateMentorAboutAsync([FromBody] WorksheetInput worksheetInput)
    {
        var result = await _profileService.UpdateMentorAboutAsync(worksheetInput.MentorAboutInfo, GetUserName());

        return result;
    }
    
    /// <summary>
    /// Метод обновит данные об образовании преподавателя в анкете.
    /// </summary>
    /// <param name="worksheetInput">Входная модель.</param>
    /// <returns>Обновленный список об образовании.</returns>
    [HttpPatch]
    [Route("mentor-educations")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> UpdateMentorEducationsAsync([FromBody] WorksheetInput worksheetInput)
    {
        var result = await _profileService.UpdateMentorEducationsAsync(worksheetInput.MentorEducations, GetUserName());

        return result;
    }
    
    /// <summary>
    /// Метод обновит данные об опыте преподавателя в анкете.
    /// </summary>
    /// <param name="worksheetInput">Входная модель.</param>
    /// <returns>Обновленный список об опыте.</returns>
    [HttpPatch]
    [Route("mentor-experience")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> UpdateMentorExperienceAsync([FromBody] WorksheetInput worksheetInput)
    {
        var result = await _profileService.UpdateMentorExperienceAsync(worksheetInput.MentorExperience, GetUserName());

        return result;
    }
    
    /// <summary>
    /// Метод получит список сертификатов для профиля пользователя.
    /// </summary>
    /// <returns>Список сертификатов.</returns>
    [HttpGet]
    [Route("certs")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<FileContentResultOutput>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<FileContentResultOutput>> GetProfileCertsAsync()
    {
        var result = await _profileService.GetProfileCertsAsync(GetUserName());

        return result;
    }

    /// <summary>
    /// Метод добавляет новые изображения сертификатов на сервер и в БД, если они ранее не были добавлены. 
    /// </summary>
    /// <param name="files">Список изображений сертификатов.</param>
    [HttpPost]
    [Route("certs")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> CreateCertsAsync([FromForm] IFormCollection files)
    {
        var result = await _profileService.CreateCertsAsync(files, GetUserName());

        return result;
    }

    /// <summary>
    /// Метод добавляет запись информации о преподавателе по дефолту.
    /// </summary>
    /// <returns>Данные анкеты.</returns>
    [HttpPost]
    [Route("default-about")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> AddDefaultMentorAboutInfoAsync()
    {
        var result = await _profileService.AddDefaultMentorAboutInfoAsync(GetUserName());

        return result;
    }
    
    /// <summary>
    /// Метод добавляет запись образования по дефолту.
    /// </summary>
    /// <returns>Данные анкеты.</returns>
    [HttpPost]
    [Route("default-education")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> AddDefaultMentorEducationAsync()
    {
        var result = await _profileService.AddDefaultMentorEducationAsync(GetUserName());

        return result;
    }
    
    /// <summary>
    /// Метод добавляет запись опыта по дефолту.
    /// </summary>
    /// <returns>Данные анкеты.</returns>
    [HttpPost]
    [Route("default-experience")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> AddDefaultMentorExperienceAsync()
    {
        var result = await _profileService.AddDefaultMentorExperienceAsync(GetUserName());

        return result;
    }
    
    /// <summary>
    /// Метод сохраняет желаемый возраст преподавателя в анкете ученика.
    /// </summary>
    /// <param name="worksheetInput">Входная модель.</param>
    /// <returns>Данные анкеты.</returns>
    [HttpPatch]
    [Route("student-mentor-age")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> SaveStudentMentorAgeAsync([FromBody] StudentMentorAgeInput studentMentorAgeInput)
    {
        var result = await _profileService.SaveStudentMentorAgeAsync(studentMentorAgeInput.AgeId, GetUserName());

        return result;
    }
    
    /// <summary>
    /// Метод сохраняет желаемый пол преподавателя в анкете ученика.
    /// </summary>
    /// <param name="worksheetInput">Входная модель.</param>
    /// <returns>Данные анкеты.</returns>
    [HttpPatch]
    [Route("student-mentor-gender")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> SaveStudentMentorGenderAsync([FromBody] StudentMentorGenderInput studentMentorGenderInput)
    {
        var result = await _profileService.SaveStudentMentorGenderAsync(studentMentorGenderInput.GenderId, GetUserName());

        return result;
    }
    
    /// <summary>
    /// Метод сохраняет комментарий в анкете ученика.
    /// </summary>
    /// <param name="worksheetInput">Входная модель.</param>
    /// <returns>Данные анкеты.</returns>
    [HttpPatch]
    [Route("student-comment")]
    [ProducesResponseType(200, Type = typeof(WorksheetOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<WorksheetOutput> SaveStudentCommentAsync([FromBody] StudentCommentInput studentCommentInput)
    {
        var result = await _profileService.SaveStudentCommentAsync(studentCommentInput.Comment, GetUserName());

        return result;
    }
}