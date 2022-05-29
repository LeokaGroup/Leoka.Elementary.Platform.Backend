﻿using AutoMapper;
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
    /// <returns>Список целей подготовки.</returns>
    public async Task<IEnumerable<PurposeTrainingOutput>> GetPurposeTrainingsAsync()
    {
        try
        {
            var result = await _profileRepository.GetPurposeTrainingsAsync();

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
        if (!mentorProfileInfo.MentorTimes.Any())
        {
            throw new EmptyTimeException();
        }

        // Проверит цели подготовки.
        if (!mentorProfileInfo.MentorTrainings.Any())
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
    /// Метод обновит список предметов преподавателя в анкете.
    /// </summary>
    /// <param name="updateItems">Список предметов для обновления.</param>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Обновленный список предметов.</returns>
    public async Task<WorksheetOutput> UpdateMentorItemsAsync(List<ProfileItemOutput> updateItems, string account)
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

            var oldItems = await _profileRepository.GetMentorItemsAsync(user.UserId);

            // Если нет предметов у преподавателя.
            if (!oldItems.MentorItems.Any())
            {
                return new WorksheetOutput();
            }

            // Проходит по старым предметам.
            for (var i = 0; i < oldItems.MentorItems.Count; i++)
            {
                // Проходит по новым предметам.
                for (var j = 0; j < updateItems.Count; j++)
                {
                    // Если номер предмета не совпадает, значит нужно менять предмет.
                    if (oldItems.MentorItems[i].ItemNumber != updateItems[j].ItemNumber)
                    {
                        oldItems.MentorItems[i].ItemNumber = updateItems[j].ItemNumber;
                    }

                    i++;
                }
            }

            var items = _mapper.Map<List<MentorProfileItemEntity>>(oldItems.MentorItems);
            
            items.ForEach(i => i.UserId = user.UserId);
            
            await _profileRepository.UpdateMentorItemsAsync(items);

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
}