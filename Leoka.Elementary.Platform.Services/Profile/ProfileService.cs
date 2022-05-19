using Leoka.Elementary.Platform.Abstractions.Profile;
using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Access.Abstraction;
using Leoka.Elementary.Platform.Core.Exceptions;
using Leoka.Elementary.Platform.Models.Profile.Input;
using Leoka.Elementary.Platform.Models.Profile.Output;
using Microsoft.AspNetCore.Http;

namespace Leoka.Elementary.Platform.Services.Profile;

/// <summary>
/// Класс реализует методы сервиса профиля пользователя.
/// </summary>
public sealed class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    
    public ProfileService(IProfileRepository profileRepository,
        IRoleRepository roleRepository,
        IUserRepository userRepository)
    {
        _profileRepository = profileRepository;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
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
    public async Task<MentorProfileInfoOutput> SaveProfileUserInfoAsync(MentorProfileInfoInput mentorProfileInfoInput, IFormCollection mentorCertificates, string account)
    {
        try
        {
            var result = new MentorProfileInfoOutput();
            
            // Получит Id пользователя.
            var user = await _userRepository.GetUserByEmailAsync(account);

            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            // Получит роль пользователя.
            var role = await _roleRepository.GetUserRoleAsync(user.UserId);

            // Если преподаватель.
            if (role == 2)
            {
                // Проверка ФИО.
                if (string.IsNullOrEmpty(mentorProfileInfoInput.FirstName) 
                    || string.IsNullOrEmpty(mentorProfileInfoInput.LastName)
                    || string.IsNullOrEmpty(mentorProfileInfoInput.SecondName))
                {
                    throw new EmptyUserFioException();
                }
            
                // Проверит контактные данные.
                if (string.IsNullOrEmpty(mentorProfileInfoInput.Email) 
                    || string.IsNullOrEmpty(mentorProfileInfoInput.PhoneNumber))
                {
                    throw new EmptyContactException();
                }
            
                // Проверит список предметов.
                if (!mentorProfileInfoInput.MentorItems.Any())
                {
                    throw new EmptyMentorItemsException();
                }

                // Проверит список цен преподавателя.
                if (!mentorProfileInfoInput.MentorPrices.Any())
                {
                    throw new EmptyPricesException();
                }
                
                // Проверит длительности занятий преподавателя.
                if (!mentorProfileInfoInput.MentorDurations.Any())
                {
                    throw new EmptyDurationException();
                }
                
                // Проверит время занятий преподавателя.
                if (!mentorProfileInfoInput.MentorTimes.Any())
                {
                    throw new EmptyTimeException();
                }
                
                // Проверит цели подготовки.
                if (!mentorProfileInfoInput.MentorTrainings.Any())
                {
                    throw new EmptyTrainingException();
                }
                
                // Проверит опыт преподавателя.
                if (!mentorProfileInfoInput.MentorExperience.Any())
                {
                    throw new EmptyExperienceException();
                }
                
                // Проверит образование преподавателя.
                if (!mentorProfileInfoInput.MentorEducations.Any())
                {
                    throw new EmptyEducationsException();
                }
                
                // Проверит сертификаты преподавателя.
                if (!mentorCertificates.Files.Any())
                {
                    throw new EmptyCertificatesException();
                }

                result = await _profileRepository.SaveProfileUserInfoAsync(mentorProfileInfoInput, mentorCertificates, user.UserId);
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
}