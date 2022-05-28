﻿using Leoka.Elementary.Platform.Models.Entities.Profile;
using Leoka.Elementary.Platform.Models.Profile.Input;
using Leoka.Elementary.Platform.Models.Profile.Output;

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
    /// <param name="urlCertificates">Список путей к изображениям сертификатов.</param>
    /// <param name="urlAvatar">Путь к изображению профиля пользователя.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Выходная модель с изменениями.</returns>
    Task<MentorProfileInfoOutput> SaveProfileUserInfoAsync(MentorProfileInfoInput mentorProfileInfoInput, string[] urlCertificates, string urlAvatar, long userId);
    
    /// <summary>
    /// Метод получит дни недели.
    /// </summary>
    /// <returns>Список дней недели.</returns>
    Task<IEnumerable<DayWeekOutput>> GetDaysWeekAsync();
    
    /// <summary>
    /// Метод получит список сертификатов пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список сертификатов.</returns>
    Task<string[]> GetUserCertsAsync(long userId);
    
    /// <summary>
    /// Метод получит аватар профиля пользователя.
    /// </summary>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Аватар профиля пользователя.</returns>
    Task<string> GetProfileAvatarAsync(string account);
    
    /// <summary>
    /// Метод получит данные анкеты пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="roleId">Id роли пользователя.</param>
    /// <returns>Данные анкеты пользователя.</returns>
    Task<WorksheetOutput> GetProfileWorkSheetAsync(long userId, int roleId);

    /// <summary>
    /// Метод получит старое название аватара пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="roleId">Id роли.</param>
    /// <returns>Название аватара.</returns>
    Task<string> GetOldAvatatName(long userId, int roleId);
    
    /// <summary>
    /// Метод обновит название аватара пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="roleId">Id роли.</param>
    /// <param name="avatarName">Название аватара.</param>
    Task UpdateAvatatName(long userId, int roleId, string avatarName);
    
    /// <summary>
    /// Метод обновит ФИО пользователя.
    /// </summary>
    /// <param name="firstName">Аккаунт.</param>
    /// <param name="lastName">Аккаунт.</param>
    /// <param name="secondName">Аккаунт.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="roleId">Роль пользователя.</param>
    /// <returns>Измененные данные.</returns>
    Task<MentorProfileInfoOutput> UpdateUserFioAsync(string firstName, string lastName, string secondName, long userId, int roleId);
    
    /// <summary>
    /// Метод обновит контактные данные пользователя.
    /// </summary>
    /// <param name="isVisibleContacts">Флаг видимости контактов.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="email">Почта.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="roleId">Роль пользователя.</param>
    /// <returns>Измененные данные.</returns>
    Task<MentorProfileInfoOutput> UpdateUserContactsAsync(bool isVisibleContacts, string phoneNumber, string email, long userId, int roleId);
    
    /// <summary>
    /// Метод получит список предметов преподавателя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список предметов.</returns>
    Task<WorksheetOutput> GetMentorItemsAsync(long userId);

    /// <summary>
    /// Метод обновит список предметов преподавателя в анкете.
    /// </summary>
    /// <param name="updateItems">Список предметов для обновления.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Обновленный список предметов.</returns>
    Task UpdateMentorItemsAsync( List<MentorProfileItemEntity> updateItems, long userId);
}