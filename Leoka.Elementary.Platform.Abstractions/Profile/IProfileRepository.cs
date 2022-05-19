﻿using Leoka.Elementary.Platform.Models.Profile.Input;
using Leoka.Elementary.Platform.Models.Profile.Output;
using Microsoft.AspNetCore.Http;

namespace Leoka.Elementary.Platform.Abstractions.Profile;

/// <summary>
/// Абстракция репозитория профиля пользователя.
/// </summary>
public interface IProfileRepository
{
    /// <summary>
    /// Метод получит информацию для профиля пользователя при входе после регитсрации.
    /// </summary>
    /// <returns>Данные о профиле.</returns>
    Task<ProfileInfoOutput> GetProfileInfoAsync();

    /// <summary>
    /// Метод получит список элементов для меню профиля пользователя.
    /// </summary>
    /// <param name="roleId">Id роли.</param>
    /// <returns>Список элементов меню.</returns>
    Task<ProfileMenuItemResult> GetProfileMenuItemsAsync(int roleId);
    
    /// <summary>
    /// Метод получит список предметов.
    /// </summary>
    /// <returns>Список предметов.</returns>
    Task<IEnumerable<ProfileItemOutput>> GetProfileItemsAsync();
    
    /// <summary>
    /// Метод получит список для выпадающего списка длительностей уроков.
    /// </summary>
    /// <returns>Список для выпадающего списка длительностей уроков.</returns>
    Task<IEnumerable<LessonDurationOutput>> GetLessonsDurationAsync();
    
    /// <summary>
    /// Метод получит список целей подготовки.
    /// </summary>
    /// <returns>Список целей подготовки.</returns>
    Task<IEnumerable<PurposeTrainingOutput>> GetPurposeTrainingsAsync();
    
    /// <summary>
    /// Метод сохранит данные анкеты пользователя.
    /// </summary>
    /// <param name="mentorProfileInfoInput">Входная модель.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Выходная модель с изменениями.</returns>
    Task<MentorProfileInfoOutput> SaveProfileUserInfoAsync(MentorProfileInfoInput mentorProfileInfoInput, IFormCollection mentorCertificates, long userId);
    
    /// <summary>
    /// Метод получит дни недели.
    /// </summary>
    /// <returns>Список дней недели.</returns>
    Task<IEnumerable<DayWeekOutput>> GetDaysWeekAsync();
}