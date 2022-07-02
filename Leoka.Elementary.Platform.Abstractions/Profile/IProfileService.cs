using Leoka.Elementary.Platform.Models.Profile.Input;
using Leoka.Elementary.Platform.Models.Profile.Output;
using Microsoft.AspNetCore.Http;

namespace Leoka.Elementary.Platform.Abstractions.Profile;

/// <summary>
/// Абстракция сервиса профиля пользователя.
/// </summary>
public interface IProfileService
{
    /// <summary>
    /// Метод получит информацию для профиля пользователя при входе после регитсрации.
    /// </summary>
    /// <returns>Данные о профиле.</returns>
    Task<ProfileInfoOutput> GetProfileInfoAsync();

    /// <summary>
    /// Метод получит список элементов для меню профиля пользователя.
    /// <param name="account">Аккаунт пользователя.</param>
    /// </summary>
    /// <returns>Список элементов меню.</returns>
    Task<ProfileMenuItemResult> GetProfileMenuItemsAsync(string account);

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
    /// <param name="account">Аккаунт пользователя.</param>
    /// <returns>Список целей подготовки.</returns>
    Task<IEnumerable<PurposeTrainingOutput>> GetPurposeTrainingsAsync(string account);

    /// <summary>
    /// Метод сохранит данные анкеты пользователя.
    /// </summary>
    /// <param name="mentorProfileInfoInput">Входная модель.</param>
    /// <param name="account">Аккаунт пользователя.</param>
    /// <returns>Выходная модель с изменениями.</returns>
    Task<MentorProfileInfoOutput> SaveProfileUserInfoAsync(string mentorProfileInfoInput,
        IFormCollection mentorFiles, string account);

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
    Task<FileContentAvatarOutput> GetProfileAvatarAsync(string account);

    /// <summary>
    /// Метод получит данные анкеты пользователя.
    /// </summary>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Данные анкеты пользователя.</returns>
    Task<WorksheetOutput> GetProfileWorkSheetAsync(string account);

    /// <summary>
    /// Метод обновит аватар пользователя.
    /// </summary>
    /// <param name="avatar">Новое изображение аватара.</param>
    /// <returns>Новый файл аватара.</returns>
    Task<FileContentAvatarOutput> UpdateAvatarAsync(IFormCollection avatar, string account);

    /// <summary>
    /// Метод обновит ФИО пользователя.
    /// </summary>
    /// <param name="firstName">Аккаунт.</param>
    /// <param name="lastName">Аккаунт.</param>
    /// <param name="secondName">Аккаунт.</param>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Измененные данные.</returns>
    Task<MentorProfileInfoOutput> UpdateUserFioAsync(string firstName, string lastName, string secondName, string account);

    /// <summary>
    /// Метод обновит контактные данные пользователя.
    /// </summary>
    /// <param name="isVisibleContacts">Флаг видимости контактов.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="email">Почта.</param>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Измененные данные.</returns>
    Task<MentorProfileInfoOutput> UpdateUserContactsAsync(bool isVisibleContacts, string phoneNumber, string email, string account);

    /// <summary>
    /// Метод обновит или добавит список предметов в анкете.
    /// </summary>
    /// <param name="updateItems">Список предметов для обновления.</param>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Обновленный список предметов.</returns>
    Task<WorksheetOutput> SaveItemsAsync(List<ProfileItemOutput> updateItems, string account);
    
    /// <summary>
    /// Метод обновит список предметов пользователя в анкете.
    /// </summary>
    /// <param name="updatePrices">Список цен для обновления.</param>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Обновленный список предметов.</returns>
    Task<WorksheetOutput> UpdateUserPricesAsync(List<UserProfilePrices> updatePrices, string account);
    
    /// <summary>
    /// Метод обновит список длительностей пользователя в анкете.
    /// </summary>
    /// <param name="updatePrices">Список длительностей для обновления.</param>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Обновленный список длительностей.</returns>
    Task<WorksheetOutput> UpdateMentorDurationsAsync(List<UserProfileDurations> updateDurations, string account);
    
    /// <summary>
    /// Метод обновит список времени преподавателя в анкете.
    /// </summary>
    /// <param name="updateTimes">Список времени для обновления.</param>
    /// <returns>Обновленный список длительностей.</returns>
    Task<WorksheetOutput> UpdateUserTimesAsync(List<UserTimes> updateTimes, string account);
    
    /// <summary>
    /// Метод обновит данные о себе преподавателя в анкете.
    /// </summary>
    /// <param name="updateAboutInfo">Список информации о себе для обновления.</param>
    /// <returns>Обновленный данные о себе.</returns>
    Task<WorksheetOutput> UpdateMentorAboutAsync(List<MentorAboutInfo> updateAboutInfo, string account);

    /// <summary>
    /// Метод обновит данные о себе преподавателя в анкете.
    /// </summary>
    /// <param name="updateAboutInfo">Список информации об образовании преподавателя для обновления.</param>
    /// <returns>Обновленный список об образовании преподавателя.</returns>
    Task<WorksheetOutput> UpdateMentorEducationsAsync(List<MentorEducations> updateEducations, string account);
    
    /// <summary>
    /// Метод обновит данные об опыте преподавателя в анкете.
    /// </summary>
    /// <param name="updateAboutInfo">Список информации об опыте преподавателя для обновления.</param>
    /// <returns>Обновленный список об опыте преподавателя.</returns>
    Task<WorksheetOutput> UpdateMentorExperienceAsync(List<MentorExperience> updateExperience, string account);
    
    /// <summary>
    /// Метод получит список сертификатов для профиля пользователя.
    /// </summary>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Список сертификатов.</returns>
    Task<IEnumerable<FileContentResultOutput>> GetProfileCertsAsync(string account);

    /// <summary>
    /// Метод добавляет новые изображения сертификатов на сервер и в БД, если они ранее не были добавлены. 
    /// </summary>
    /// <param name="files">Список изображений сертификатов.</param>
    Task<WorksheetOutput> CreateCertsAsync(IFormCollection files, string account);

    /// <summary>
    /// Метод добавляет запись информации о преподавателе по дефолту.
    /// </summary>
    /// <param name="account">Логин.</param>
    /// <returns>Данные анкеты.</returns>
    Task<WorksheetOutput> AddDefaultMentorAboutInfoAsync(string account);
    
    /// <summary>
    /// Метод добавляет запись образования по дефолту.
    /// </summary>
    /// <param name="account">Логин.</param>
    /// <returns>Данные анкеты.</returns>
    Task<WorksheetOutput> AddDefaultMentorEducationAsync(string account);
    
    /// <summary>
    /// Метод добавляет запись опыта по дефолту.
    /// </summary>
    /// <param name="account">Логин.</param>
    /// <returns>Данные анкеты.</returns>
    Task<WorksheetOutput> AddDefaultMentorExperienceAsync(string account);

    /// <summary>
    /// Метод сохраняет желаемый возраст преподавателя в анкете ученика.
    /// </summary>
    /// <param name="ageId">Id возраста.</param>
    /// <param name="account">Логин.</param>
    /// <returns>Данные анкеты.</returns>
    Task<WorksheetOutput> SaveStudentMentorAgeAsync(int ageId, string account);

    /// <summary>
    /// Метод сохраняет желаемый пол преподавателя в анкете ученика.
    /// </summary>
    /// <param name="genderId">Id пола.</param>
    /// <param name="account">Логин.</param>
    /// <returns>Данные анкеты.</returns>
    Task<WorksheetOutput> SaveStudentMentorGenderAsync(int genderId, string account);

    /// <summary>
    /// Метод сохраняет комментарий в анкете ученика.
    /// </summary>
    /// <param name="comment">Комментарий студента.</param>
    /// <param name="account">Логин.</param>
    /// <returns>Данные анкеты.</returns>
    Task<WorksheetOutput> SaveStudentCommentAsync(string comment, string account);
}