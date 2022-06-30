using Leoka.Elementary.Platform.Models.Entities.Profile;
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
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список целей подготовки.</returns>
    Task<IEnumerable<PurposeTrainingOutput>> GetPurposeTrainingsAsync(long userId);
    
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
    /// Метод получит список предметов пользователя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="roleId">Id роли пользователя.</param>
    /// <returns>Список предметов.</returns>
    Task<WorksheetOutput> GetUserItemsAsync(long userId, int roleId);

    /// <summary>
    /// Метод обновит список предметов преподавателя в анкете.
    /// </summary>
    /// <param name="updateItems">Список предметов для обновления.</param>
    /// <returns>Обновленный список предметов.</returns>
    Task UpdateMentorItemsAsync(List<MentorProfileItemEntity> updateItems);
    
    /// <summary>
    /// Метод обновит список цен пользователя в анкете.
    /// </summary>
    /// <param name="updateItems">Список предметов для обновления.</param>
    /// <returns>Обновленный список предметов.</returns>
    Task UpdateUserPricesAsync(List<UserLessonPriceEntity> updateItems);
    
    /// <summary>
    /// Метод получит список цен пользователя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список цен.</returns>
    Task<WorksheetOutput> GetUserPricesAsync(long userId);
    
    /// <summary>
    /// Метод получит список длительностей преподавателя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список длительностей.</returns>
    Task<WorksheetOutput> GetMentorDurationsAsync(long userId);
    
    /// <summary>
    /// Метод обновит список длительностей пользователя в анкете.
    /// </summary>
    /// <param name="updateItems">Список длительностей для обновления.</param>
    /// <returns>Обновленный список длительностей.</returns>
    Task UpdateMentorDurationsAsync(List<UserLessonDurationEntity> updateDurations);
    
    /// <summary>
    /// Метод получит список времен пользователя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список времен.</returns>
    Task<WorksheetOutput> GetUserTimesAsync(long userId);
    
    /// <summary>
    /// Метод обновит время преподавателя в анкете.
    /// </summary>
    /// <param name="updateTimes">Список времени для обновления.</param>
    /// <returns>Обновленный список длительностей.</returns>
    Task UpdateMentorTimesAsync(List<UserTimeEntity> updateTimes);

    /// <summary>
    /// Метод обновит данные о себе преподавателя в анкете.
    /// </summary>
    /// <param name="updateAboutInfo">Список информации о себе для обновления.</param>
    /// <returns>Обновленный данные о себе.</returns>
    Task UpdateMentorAboutAsync(List<MentorAboutInfoEntity> updateAboutInfo);

    /// <summary>
    /// Метод получит Id дня по его системному названию.
    /// </summary>
    /// <param name="sysName">Системное название.</param>
    /// <returns>Id дня</returns>
    Task<int> GetDayIdBySysNameAsync(string sysName);
    
    /// <summary>
    /// Метод получит данные о себе преподавателя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные о себе.</returns>
    Task<WorksheetOutput> GetMentorAboutInfoAsync(long userId);
    
    /// <summary>
    /// Метод получит данные об образовании преподавателя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные об образовании.</returns>
    Task<WorksheetOutput> GetMentorEducationsAsync(long userId);
    
    /// <summary>
    /// Метод обновит данные об образовании преподавателя в анкете.
    /// </summary>
    /// <param name="updateAboutInfo">Список информации об образовании для обновления.</param>
    /// <returns>Обновленные данные об образовании.</returns>
    Task UpdateMentorEducationsAsync(List<MentorEducationEntity> updateEducations);
    
    /// <summary>
    /// Метод получит данные об опыте преподавателя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные об опыте.</returns>
    Task<WorksheetOutput> GetMentorExperienceAsync(long userId);
    
    /// <summary>
    /// Метод обновит данные об опыте преподавателя в анкете.
    /// </summary>
    /// <param name="updateAboutInfo">Список информации об опыте для обновления.</param>
    /// <returns>Обновленные данные об опыте.</returns>
    Task UpdateMentorExperienceAsync(List<MentorExperienceEntity> updateExperience);

    /// <summary>
    /// Метод добавляет изображения сертификатов пользователя.
    /// </summary>
    /// <param name="fileNames">Список названий изображений.</param>
    /// <param name="userId">Id пользователя.</param>
    Task AddProfileUserCertsAsync(string[] fileNames, long userId);
    
    /// <summary>
    /// Метод добавляет запись информации о преподавателе по дефолту.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные анкеты.</returns>
    Task AddDefaultMentorAboutInfoAsync(long userId);
    
    /// <summary>
    /// Метод добавляет запись информации об образовании по дефолту.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные анкеты.</returns>
    Task AddDefaultMentorEducationAsync(long userId);
    
    /// <summary>
    /// Метод добавляет запись информации об опыте по дефолту.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные анкеты.</returns>
    Task AddDefaultMentorExperienceAsync(long userId);

    /// <summary>
    /// Метод добавляет новые предметы преподавателю.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="addItems">Список предметов для добавления.</param>
    Task AddMentorItemsAsync(List<ProfileItemOutput> addItems, long userId);
    
    /// <summary>
    /// Метод добавляет новые предметы ученика.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="addItems">Список предметов для добавления.</param>
    Task AddStudentItemsAsync(List<ProfileItemOutput> addItems, long userId);
    
    /// <summary>
    /// Метод обновит список предметов ученика в анкете.
    /// </summary>
    /// <param name="updateItems">Список предметов для обновления.</param>
    /// <returns>Обновленный список предметов.</returns>
    Task UpdateStudentItemsAsync(List<StudentProfileItemEntity> updateItems);

    /// <summary>
    /// Метод добавляет цены пользователя.
    /// </summary>
    /// <param name="updatePrices">Добавляемые цены.</param>
    /// <param name="userId">Id пользователя.</param>
    Task AddUserPricesAsync(List<UserProfilePrices> addPrices, long userId);

    /// <summary>
    /// Метод добавляет длительности пользователя.
    /// </summary>
    /// <param name="addDurations">Добавляемые длительности пользователя.</param>
    /// <param name="userId">Id пользователя.</param>
    Task AddUserDurationsAsync(List<UserProfileDurations> addDurations, long userId);
    
    /// <summary>
    /// Метод добавляет время пользователя.
    /// </summary>
    /// <param name="addTimes">Добавляемое время пользователя.</param>
    /// <param name="userId">Id пользователя.</param>
    Task AddUserTimesAsync(List<UserTimes> addTimes, long userId);
}