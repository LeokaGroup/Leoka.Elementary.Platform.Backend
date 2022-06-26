using AutoMapper;
using Leoka.Elementary.Platform.Abstractions.Profile;
using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Access.Abstraction;
using Leoka.Elementary.Platform.Core.Exceptions;
using Leoka.Elementary.Platform.FTP.Abstractions;
using Leoka.Elementary.Platform.Models.Entities.Profile;
using Leoka.Elementary.Platform.Models.Profile.Input;
using Leoka.Elementary.Platform.Models.Profile.Output;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Leoka.Elementary.Platform.Services.Profile;

/// <summary>
/// Класс реализует методы сервиса профиля пользователя.
/// </summary>
public sealed class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IFtpService _ftpService;
    private readonly IMapper _mapper;

    public ProfileService(IProfileRepository profileRepository,
        IRoleRepository roleRepository,
        IUserRepository userRepository,
        IFtpService ftpService,
        IMapper mapper)
    {
        _profileRepository = profileRepository;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _ftpService = ftpService;
        _mapper = mapper;
    }

    public async Task<ProfileInfoOutput> GetProfileInfoAsync()
    {
        try
        {
            var result = await _profileRepository.GetProfileInfoAsync();

            return result;
        }

        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит список элементов для меню профиля пользователя.
    /// <param name="account">Аккаунт пользователя.</param>
    /// </summary>
    /// <returns>Список элементов меню.</returns>
    public async Task<ProfileMenuItemResult> GetProfileMenuItemsAsync(string account)
    {
        try
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }

            // Проверит существование пользователя.
            var user = await _userRepository.GetUserByEmailAsync(account);

            if (user is null)
            {
                throw new NotFoundUserException(account);
            }

            // Проверит роль пользователя.
            var roleId = await _roleRepository.GetUserRoleAsync(user.UserId);

            // Получит список элементов меню профиля в зависимости от роли.
            var items = await _profileRepository.GetProfileMenuItemsAsync(roleId);

            return items;
        }

        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит список предметов.
    /// </summary>
    /// <returns>Список предметов.</returns>
    public async Task<IEnumerable<ProfileItemOutput>> GetProfileItemsAsync()
    {
        try
        {
            var result = await _profileRepository.GetProfileItemsAsync();

            return result;
        }

        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит список для выпадающего списка длительностей уроков.
    /// </summary>
    /// <returns>Список для выпадающего списка длительностей уроков.</returns>
    public async Task<IEnumerable<LessonDurationOutput>> GetLessonsDurationAsync()
    {
        try
        {
            var result = await _profileRepository.GetLessonsDurationAsync();

            return result;
        }

        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит список целей подготовки.
    /// </summary>
    /// <param name="account">Аккаунт пользователя.</param>
    /// <returns>Список целей подготовки.</returns>
    public async Task<IEnumerable<PurposeTrainingOutput>> GetPurposeTrainingsAsync(string account)
    {
        try
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }

            // Проверит существование пользователя.
            var user = await _userRepository.GetUserByEmailAsync(account);

            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            var result = await _profileRepository.GetPurposeTrainingsAsync(user.UserId);

            return result;
        }

        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод сохранит данные анкеты пользователя.
    /// </summary>
    /// <param name="mentorProfileInfoInput">Входная модель.</param>
    /// <param name="account">Аккаунт пользователя.</param>
    /// <returns>Выходная модель с изменениями.</returns>
    public async Task<MentorProfileInfoOutput> SaveProfileUserInfoAsync(string mentorProfileInfoDataInput,
        IFormCollection mentorFiles, string account)
    {
        try
        {
            var result = new MentorProfileInfoOutput();
            var mentorProfileInfo = JsonConvert.DeserializeObject<MentorProfileInfoInput>(mentorProfileInfoDataInput);

            // Получит Id пользователя.
            var user = await _userRepository.GetUserByEmailAsync(account);

            if (user is null)
            {
                throw new NotFoundUserException(account);
            }

            // Получит роль пользователя.
            var role = await _roleRepository.GetUserRoleAsync(user.UserId);

            // Если преподаватель.
            if (role == 2 && mentorProfileInfo is not null)
            {
                CheckInputParamsSaveProfileMentor(mentorProfileInfo, mentorFiles);
                
                var urlAvatar = mentorFiles.Files
                    .Where(f => f.Name.Equals("profileImage"))
                    .Select(f => f.FileName)
                    .FirstOrDefault();

                var urlMentorCertificates = mentorFiles.Files
                    .Where(f => f.Name.Equals("mentorCertificates"))
                    .Select(f => f.FileName)
                    .ToArray();
                
                // Добавит файлы на сервер.
                await _ftpService.UploadProfileFilesFtpAsync(mentorFiles.Files, user.UserId);

                result = await _profileRepository.SaveProfileUserInfoAsync(mentorProfileInfo, urlMentorCertificates,
                    urlAvatar, user.UserId);
            }

            return result;
        }

        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит дни недели.
    /// </summary>
    /// <returns>Список дней недели.</returns>
    public async Task<IEnumerable<DayWeekOutput>> GetDaysWeekAsync()
    {
        try
        {
            var result = await _profileRepository.GetDaysWeekAsync();

            return result;
        }

        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод проверит входные параметры преподавателя.
    /// </summary>
    /// <param name="mentorProfileInfo">Входная модель.</param>
    /// <param name="mentorFiles">Файлы.</param>
    private void CheckInputParamsSaveProfileMentor(MentorProfileInfoInput mentorProfileInfo, IFormCollection mentorFiles)
    {
        // Проверка ФИО.
        if (string.IsNullOrEmpty(mentorProfileInfo.FirstName)
            || string.IsNullOrEmpty(mentorProfileInfo.LastName)
            || string.IsNullOrEmpty(mentorProfileInfo.SecondName))
        {
            throw new EmptyUserFioException();
        }

        // Проверит контактные данные.
        if (string.IsNullOrEmpty(mentorProfileInfo.Email)
            || string.IsNullOrEmpty(mentorProfileInfo.PhoneNumber))
        {
            throw new EmptyContactException();
        }

        // Проверит список предметов.
        if (!mentorProfileInfo.MentorItems.Any())
        {
            throw new EmptyMentorItemsException();
        }

        // Проверит список цен преподавателя.
        if (!mentorProfileInfo.MentorPrices.Any())
        {
            throw new EmptyPricesException();
        }

        // Проверит длительности занятий преподавателя.
        if (!mentorProfileInfo.MentorDurations.Any())
        {
            throw new EmptyDurationException();
        }

        // Проверит время занятий преподавателя.
        if (!mentorProfileInfo.UserTimes.Any())
        {
            throw new EmptyTimeException();
        }

        // Проверит цели подготовки.
        if (!mentorProfileInfo.UserTrainings.Any())
        {
            throw new EmptyTrainingException();
        }

        // Проверит опыт преподавателя.
        if (!mentorProfileInfo.MentorExperience.Any())
        {
            throw new EmptyExperienceException();
        }

        // Проверит образование преподавателя.
        if (!mentorProfileInfo.MentorEducations.Any())
        {
            throw new EmptyEducationsException();
        }

        // Проверит файлы преподавателя.
        if (!mentorFiles.Files.Any())
        {
            throw new EmptyFilesException();
        }

        // Проверит информацию о преподавателе.
        if (!mentorProfileInfo.MentorAboutInfo.Any())
        {
            throw new EmptyAboutInfoException();
        }
    }
    
    /// <summary>
    /// Метод получит список сертификатов пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список сертификатов.</returns>
    public async Task<string[]> GetUserCertsAsync(long userId)
    {
        try
        {
            var result = await _profileRepository.GetUserCertsAsync(userId);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит аватар профиля пользователя.
    /// </summary>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Аватар профиля пользователя.</returns>
    public async Task<FileContentAvatarOutput> GetProfileAvatarAsync(string account)
    {
        try
        {
            var user = await _userRepository.GetUserByEmailAsync(account);
            var avatar = await _profileRepository.GetProfileAvatarAsync(account);
            var result = await _ftpService.GetProfileAvatarAsync(user.UserId, avatar);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит данные анкеты пользователя.
    /// </summary>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Данные анкеты пользователя.</returns>
    public async Task<WorksheetOutput> GetProfileWorkSheetAsync(string account)
    {
        try
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }

            var user = await _userRepository.GetUserByEmailAsync(account);

            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            // Проверит роль пользователя.
            var roleId = await _roleRepository.GetUserRoleAsync(user.UserId);

            var result = await _profileRepository.GetProfileWorkSheetAsync(user.UserId, roleId);
            
            // Запишет ФИО пользователя, если из данных анкеты его нет.
            if (string.IsNullOrEmpty(result.FirstName) 
                && string.IsNullOrEmpty(result.LastName)
                && string.IsNullOrEmpty(result.SecondName))
            {
                var fio = user.FirstName.Split(" ");
                result.FirstName = fio[0];
                result.LastName = fio[1];
                result.SecondName = fio[2];
            }
            
            // Запишет Email, если из данных анкеты его нет.
            if (string.IsNullOrEmpty(result.Email))
            {
                result.Email = user.Email;
            }
            
            // Запишет номер телефона, если из данных анкеты его нет.
            if (string.IsNullOrEmpty(result.PhoneNumber))
            {
                result.PhoneNumber = user.PhoneNumber;
            }

            result.UserRole = roleId;

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод обновит аватар пользователя.
    /// </summary>
    /// <param name="avatar">Новое изображение аватара.</param>
    /// <returns>Новый файл аватара.</returns>
    public async Task<FileContentAvatarOutput> UpdateAvatarAsync(IFormCollection avatar, string account)
    {
        try
        {
            var result = new FileContentAvatarOutput();
            
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            if (!avatar.Files.Any())
            {
                throw new EmptyAvatarException(account);
            }

            var user = await _userRepository.GetUserByEmailAsync(account);

            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            // Получит старое название аватара пользователя.
            var roleId = await _roleRepository.GetUserRoleAsync(user.UserId);
            var oldAvatarName = await _profileRepository.GetOldAvatatName(user.UserId, roleId);

            // Удалит старый аватар с сервера и добавит новый.
            await _ftpService.UpdateAvatarAsync(user.UserId, avatar, oldAvatarName);

            var file = avatar.Files.FirstOrDefault();

            if (file is not null)
            {
                // Запишет новый аватар в БД.
                await _profileRepository.UpdateAvatatName(user.UserId, roleId, file.FileName);
            
                // Получит новый файл.
                result = await _ftpService.GetProfileAvatarAsync(user.UserId, file.FileName);
            }

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод обновит ФИО пользователя.
    /// </summary>
    /// <param name="firstName">Аккаунт.</param>
    /// <param name="lastName">Аккаунт.</param>
    /// <param name="secondName">Аккаунт.</param>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Измененные данные.</returns>
    public async Task<MentorProfileInfoOutput> UpdateUserFioAsync(string firstName, string lastName, string secondName, string account)
    {
        try
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(secondName))
            {
                throw new EmptyUserFioException();
            }
            
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }

            var user = await _userRepository.GetUserByEmailAsync(account);
            
            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            var roleId = await _roleRepository.GetUserRoleAsync(user.UserId);
            
            // Обновит фио пользователя.
            var result = await _profileRepository.UpdateUserFioAsync(firstName, lastName, secondName, user.UserId, roleId);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод обновит контактные данные пользователя.
    /// </summary>
    /// <param name="isVisibleContacts">Флаг видимости контактов.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="email">Почта.</param>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Измененные данные.</returns>
    public async Task<MentorProfileInfoOutput> UpdateUserContactsAsync(bool isVisibleContacts, string phoneNumber, string email, string account)
    {
        try
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(email))
            {
                throw new EmptyContactUserInfoException(account);
            }
            
            var user = await _userRepository.GetUserByEmailAsync(account);
            
            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            var roleId = await _roleRepository.GetUserRoleAsync(user.UserId);

            var result = await _profileRepository.UpdateUserContactsAsync(isVisibleContacts, phoneNumber, email, user.UserId, roleId);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод обновит или добавит список предметов в анкете.
    /// </summary>
    /// <param name="updateItems">Список предметов для обновления.</param>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Обновленный список предметов.</returns>
    public async Task<WorksheetOutput> SaveItemsAsync(List<ProfileItemOutput> updateItems, string account)
    {
        try
        {
            // Если нет предметов.
            if (!updateItems.Any())
            {
                throw new EmptyMentorItemsException();
            }
            
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            var user = await _userRepository.GetUserByEmailAsync(account);
            
            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            // Получаем роль пользователя.
            var roleId = await _roleRepository.GetUserRoleAsync(user.UserId);

            List<ProfileItemOutput> addItems;

            // Если преподаватель.
            if (roleId == 2)
            {
                // Получаем список предметов преподавателя.
                var oldItems = await _profileRepository.GetUserItemsAsync(user.UserId, roleId);

                // Если нет предметов у преподавателя, то добавляем из входного списка.
                if (!oldItems.UserItems.Any())
                {
                    addItems = updateItems;
                    
                    // Предметов еще не было, добавляем их.
                    await _profileRepository.AddMentorItemsAsync(addItems, user.UserId);
                }

                // Обновляем предметы преподавателя.
                else
                {
                    // Проходит по старым предметам.
                    for (var i = 0; i < oldItems.UserItems.Count; i++)
                    {
                        // Проходит по новым предметам.
                        for (var j = 0; j < updateItems.Count; j++)
                        {
                            // Если номер предмета не совпадает, значит нужно менять предмет.
                            if (oldItems.UserItems[i].ItemNumber != updateItems[j].ItemNumber)
                            {
                                oldItems.UserItems[i].ItemNumber = updateItems[j].ItemNumber;
                            }
            
                            i++;
                        }
                    }

                    addItems = oldItems.UserItems;

                    var items = _mapper.Map<List<MentorProfileItemEntity>>(addItems);
            
                    items.ForEach(i => i.UserId = user.UserId);
            
                    await _profileRepository.UpdateMentorItemsAsync(items);
                }
            }

            // Если ученик.
            if (roleId == 1)
            {
                // Получаем список предметов ученика.
                var studentItems = await _profileRepository.GetUserItemsAsync(user.UserId, roleId);
                
                // Если нет предметов у преподавателя.
                if (!studentItems.UserItems.Any())
                {
                    addItems = updateItems;
                    
                    // Предметов еще не было, добавляем их.
                    await _profileRepository.AddStudentItemsAsync(addItems, user.UserId);
                }

                // Обновляем предметы ученика.
                else
                {
                    // Проходит по старым предметам.
                    for (var i = 0; i < studentItems.UserItems.Count; i++)
                    {
                        // Проходит по новым предметам.
                        for (var j = 0; j < updateItems.Count; j++)
                        {
                            // Если номер предмета не совпадает, значит нужно менять предмет.
                            if (studentItems.UserItems[i].ItemNumber != updateItems[j].ItemNumber)
                            {
                                studentItems.UserItems[i].ItemNumber = updateItems[j].ItemNumber;
                            }
            
                            i++;
                        }
                    }

                    addItems = studentItems.UserItems;

                    var items = _mapper.Map<List<StudentProfileItemEntity>>(addItems);
            
                    items.ForEach(i => i.UserId = user.UserId);
            
                    await _profileRepository.UpdateStudentItemsAsync(items);
                }
            }

            var result = await GetProfileWorkSheetAsync(account);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод обновит список предметов преподавателя в анкете.
    /// </summary>
    /// <param name="updatePrices">Список цен для обновления.</param>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Обновленный список предметов.</returns>
    public async Task<WorksheetOutput> UpdateMentorPricesAsync(List<MentorProfilePrices> updatePrices, string account)
    {
        try
        {
            // Если нет цен.
            if (!updatePrices.Any())
            {
                throw new EmptyPricesException();
            }
            
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            var user = await _userRepository.GetUserByEmailAsync(account);
            
            if (user is null)
            {
                throw new NotFoundUserException(account);
            }

            var oldPrices = await _profileRepository.GetMentorPricesAsync(user.UserId);
            
            // Если нет цен у преподавателя.
            if (!oldPrices.MentorPrices.Any())
            {
                return new WorksheetOutput();
            }

            // Проходит по старым ценам.
            for (var i = 0; i < oldPrices.MentorPrices.Count; i++)
            {
                // Проходит по новым ценам.
                for (var j = 0; j < updatePrices.Count; j++)
                {
                    // Если цены не совпадает, значит нужно менять цену.
                    if (oldPrices.MentorPrices[i].Price != updatePrices[j].Price)
                    {
                        oldPrices.MentorPrices[i].Price = updatePrices[j].Price;
                    }
            
                    i++;
                }
            }
            
            var items = _mapper.Map<List<MentorLessonPriceEntity>>(oldPrices.MentorPrices);
            
            items.ForEach(i => i.UserId = user.UserId);
            
            await _profileRepository.UpdateMentorPricesAsync(items);

            var result = await GetProfileWorkSheetAsync(account);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод обновит список длительностей преподавателя в анкете.
    /// </summary>
    /// <param name="updatePrices">Список длительностей для обновления.</param>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Обновленный список длительностей.</returns>
    public async Task<WorksheetOutput> UpdateMentorDurationsAsync(List<MentorProfileDurations> updateDurations, string account)
    {
        try
        {
            // Если нет длительностей.
            if (!updateDurations.Any())
            {
                throw new EmptyDurationException();
            }
            
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            var user = await _userRepository.GetUserByEmailAsync(account);
            
            if (user is null)
            {
                throw new NotFoundUserException(account);
            }

            var oldDurations = await _profileRepository.GetMentorDurationsAsync(user.UserId);
            
            // Если нет длительностей у преподавателя.
            if (!oldDurations.MentorDurations.Any())
            {
                return new WorksheetOutput();
            }

            // Проходит по старым длительностям.
            for (var i = 0; i < oldDurations.MentorDurations.Count; i++)
            {
                // Проходит по новым длительностям.
                for (var j = 0; j < updateDurations.Count; j++)
                {
                    // Если номер предмета не совпадает, значит нужно менять предмет.
                    if (oldDurations.MentorDurations[i].Time != updateDurations[j].Time)
                    {
                        oldDurations.MentorDurations[i].Time = updateDurations[j].Time;
                    }
            
                    i++;
                }
            }

            var items = _mapper.Map<List<MentorLessonDurationEntity>>(oldDurations.MentorDurations);
            
            items.ForEach(i => i.UserId = user.UserId);
            
            await _profileRepository.UpdateMentorDurationsAsync(items);
            
            var result = await GetProfileWorkSheetAsync(account);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод обновит список времени преподавателя в анкете.
    /// </summary>
    /// <param name="updateTimes">Входная модель.</param>
    /// <returns>Обновленный список длительностей.</returns>
    public async Task<WorksheetOutput> UpdateUserTimesAsync(List<UserTimes> updateTimes, string account)
    {
        try
        {
            // Если нет времени.
            if (!updateTimes.Any())
            {
                throw new EmptyTimeException();
            }
            
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            var user = await _userRepository.GetUserByEmailAsync(account);
            
            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            var oldTimes = await _profileRepository.GetUserTimesAsync(user.UserId);
            
            // Если нет времени у преподавателя.
            if (!oldTimes.UserTimes.Any())
            {
                return new WorksheetOutput();
            }

            // Проходит по старым временам.
            for (var i = 0; i < oldTimes.UserTimes.Count; i++)
            {
                // Проходит по новым временам.
                for (var j = 0; j < updateTimes.Count; j++)
                {
                    // Если системное название времени не совпадает, значит нужно менять время.
                    if (!oldTimes.UserTimes[i].DaySysName.Equals(updateTimes[j].DaySysName))
                    {
                        oldTimes.UserTimes[i].DaySysName = updateTimes[j].DaySysName;
                        oldTimes.UserTimes[i].DayId = await _profileRepository.GetDayIdBySysNameAsync(updateTimes[j].DaySysName);
                    }
            
                    i++;
                }
            }

            var items = _mapper.Map<List<UserTimeEntity>>(oldTimes.UserTimes);
            
            items.ForEach(i => i.UserId = user.UserId);
            
            await _profileRepository.UpdateMentorTimesAsync(items);
            
            var result = await GetProfileWorkSheetAsync(account);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод обновит данные о себе преподавателя в анкете.
    /// </summary>
    /// <param name="updateAboutInfo">Список информации о себе для обновления.</param>
    /// <returns>Обновленный данные о себе.</returns>
    public async Task<WorksheetOutput> UpdateMentorAboutAsync(List<MentorAboutInfo> updateAboutInfo, string account)
    {
        try
        {
            // Если нет данных о себе.
            if (!updateAboutInfo.Any())
            {
                throw new EmptyAboutInfoException();
            }
            
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            var user = await _userRepository.GetUserByEmailAsync(account);
            
            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            var oldAboutInfo = await _profileRepository.GetMentorAboutInfoAsync(user.UserId);
            
            // Если нет данных о себе у преподавателя.
            if (!oldAboutInfo.MentorAboutInfo.Any())
            {
                return new WorksheetOutput();
            }

            // Проходит по данным о себе.
            for (var i = 0; i < oldAboutInfo.MentorAboutInfo.Count; i++)
            {
                // Проходит по новым данным о себе.
                for (var j = 0; j < updateAboutInfo.Count; j++)
                {
                    // Если системное данные о себе не совпадает, значит нужно менять данные о себе.
                    if (!oldAboutInfo.MentorAboutInfo[i].AboutInfoText.Equals(updateAboutInfo[j].AboutInfoText))
                    {
                        oldAboutInfo.MentorAboutInfo[i].AboutInfoText = updateAboutInfo[j].AboutInfoText;
                    }
            
                    i++;
                }
            }

            var items = _mapper.Map<List<MentorAboutInfoEntity>>(oldAboutInfo.MentorAboutInfo);
            
            items.ForEach(i => i.UserId = user.UserId);
            
            await _profileRepository.UpdateMentorAboutAsync(items);
            
            var result = await GetProfileWorkSheetAsync(account);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод обновит данные о себе преподавателя в анкете.
    /// </summary>
    /// <param name="updateAboutInfo">Список информации об образовании преподавателя для обновления.</param>
    /// <returns>Обновленный список об образовании преподавателя.</returns>
    public async Task<WorksheetOutput> UpdateMentorEducationsAsync(List<MentorEducations> updateEducations, string account)
    {
        try
        {
            // Если нет данных об образовании.
            if (!updateEducations.Any())
            {
                throw new EmptyEducationsException();
            }
            
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            var user = await _userRepository.GetUserByEmailAsync(account);
            
            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            var oldEducations = await _profileRepository.GetMentorEducationsAsync(user.UserId);
            
            // Если нет данных об образовании у преподавателя.
            if (!oldEducations.MentorEducations.Any())
            {
                return new WorksheetOutput();
            }

            // Проходит по данным об образовании у преподавателя.
            for (var i = 0; i < oldEducations.MentorEducations.Count; i++)
            {
                // Проходит по новым данным об образовании у преподавателя.
                for (var j = 0; j < updateEducations.Count; j++)
                {
                    // Если системное данные об образовании не совпадает, значит нужно менять данные об образовании.
                    if (!oldEducations.MentorEducations[i].EducationText.Equals(updateEducations[j].EducationText))
                    {
                        oldEducations.MentorEducations[i].EducationText = updateEducations[j].EducationText;
                    }
            
                    i++;
                }
            }

            var items = _mapper.Map<List<MentorEducationEntity>>(oldEducations.MentorEducations);
            
            items.ForEach(i => i.UserId = user.UserId);
            
            await _profileRepository.UpdateMentorEducationsAsync(items);
            
            var result = await GetProfileWorkSheetAsync(account);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод обновит данные об опыте преподавателя в анкете.
    /// </summary>
    /// <param name="updateAboutInfo">Список информации об опыте преподавателя для обновления.</param>
    /// <returns>Обновленный список об опыте преподавателя.</returns>
    public async Task<WorksheetOutput> UpdateMentorExperienceAsync(List<MentorExperience> updateExperience, string account)
    {
        try
        {
            // Если нет данных об опыте.
            if (!updateExperience.Any())
            {
                throw new EmptyExperienceException();
            }
            
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            var user = await _userRepository.GetUserByEmailAsync(account);
            
            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            var oldExperience = await _profileRepository.GetMentorExperienceAsync(user.UserId);
            
            // Если нет данных об опыте у преподавателя.
            if (!oldExperience.MentorExperience.Any())
            {
                return new WorksheetOutput();
            }
            
            // Проходит по данным об образовании у преподавателя.
            for (var i = 0; i < oldExperience.MentorExperience.Count; i++)
            {
                // Проходит по новым данным об образовании у преподавателя.
                for (var j = 0; j < updateExperience.Count; j++)
                {
                    // Если системное данные об образовании не совпадает, значит нужно менять данные об образовании.
                    if (!oldExperience.MentorExperience[i].ExperienceText.Equals(updateExperience[j].ExperienceText))
                    {
                        oldExperience.MentorExperience[i].ExperienceText = updateExperience[j].ExperienceText;
                    }
            
                    i++;
                }
            }
            
            var items = _mapper.Map<List<MentorExperienceEntity>>(oldExperience.MentorExperience);
            
            items.ForEach(i => i.UserId = user.UserId);
            
            await _profileRepository.UpdateMentorExperienceAsync(items);
            
            var result = await GetProfileWorkSheetAsync(account);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    /// <summary>
    /// Метод получит список сертификатов для профиля пользователя.
    /// </summary>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Список сертификатов.</returns>
    public async Task<IEnumerable<FileContentResultOutput>> GetProfileCertsAsync(string account)
    {
        try
        {
            var user = await _userRepository.GetUserByEmailAsync(account);
            IEnumerable<FileContentResultOutput> result = null;

            if (user is null)
            {
                throw new NotFoundUserException(account);
            }

            // Получит список сертификатов пользователя.
            var certsNames = await GetUserCertsAsync(user.UserId);

            if (certsNames.Any())
            {
                // Получит список файлов сертификатов с сервера.
                result = await _ftpService.GetUserCertsFilesAsync(user.UserId, certsNames);
            }

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод добавляет новые изображения сертификатов на сервер и в БД, если они ранее не были добавлены. 
    /// </summary>
    /// <param name="files">Список изображений сертификатов.</param>
    public async Task<WorksheetOutput> CreateCertsAsync(IFormCollection files, string account)
    {
        try
        {
            if (!files.Files.Any())
            {
                throw new EmptyFilesException();
            }

            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            // Проверит существование пользователя.
            var user = await _userRepository.GetUserByEmailAsync(account);

            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            // Загружает изображения сертификатов пользователя на сервер.
            await _ftpService.UploadProfileFilesFtpAsync(files.Files, user.UserId);
            
            // Добавляет изображения в БД.
            await _profileRepository.AddProfileUserCertsAsync(files.Files.Select(x => x.FileName).ToArray(), user.UserId);
            
            var result = await GetProfileWorkSheetAsync(account);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод добавляет запись информации о преподавателе по дефолту.
    /// </summary>
    /// <param name="account">Логин.</param>
    /// <returns>Данные анкеты.</returns>
    public async Task<WorksheetOutput> AddDefaultMentorAboutInfoAsync(string account)
    {
        try
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            var user = await _userRepository.GetUserByEmailAsync(account);
            
            if (user is null)
            {
                throw new NotFoundUserException(account);
            }

            await _profileRepository.AddDefaultMentorAboutInfoAsync(user.UserId);
            
            var result = await GetProfileWorkSheetAsync(account);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод добавляет запись образования по дефолту.
    /// </summary>
    /// <param name="account">Логин.</param>
    /// <returns>Данные анкеты.</returns>
    public async Task<WorksheetOutput> AddDefaultMentorEducationAsync(string account)
    {
        try
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            var user = await _userRepository.GetUserByEmailAsync(account);
            
            if (user is null)
            {
                throw new NotFoundUserException(account);
            }

            await _profileRepository.AddDefaultMentorEducationAsync(user.UserId);
            
            var result = await GetProfileWorkSheetAsync(account);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод добавляет запись опыта по дефолту.
    /// </summary>
    /// <param name="account">Логин.</param>
    /// <returns>Данные анкеты.</returns>
    public async Task<WorksheetOutput> AddDefaultMentorExperienceAsync(string account)
    {
        try
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new NotFoundUserException(account);
            }
            
            var user = await _userRepository.GetUserByEmailAsync(account);
            
            if (user is null)
            {
                throw new NotFoundUserException(account);
            }

            await _profileRepository.AddDefaultMentorExperienceAsync(user.UserId);
            
            var result = await GetProfileWorkSheetAsync(account);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}