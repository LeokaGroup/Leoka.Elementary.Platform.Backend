using AutoMapper;
using Leoka.Elementary.Platform.Abstractions.Profile;
using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Core.Utils;
using Leoka.Elementary.Platform.Models.Entities.Profile;
using Leoka.Elementary.Platform.Models.Profile.Input;
using Leoka.Elementary.Platform.Models.Profile.Output;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.Services.Profile;

/// <summary>
/// Класс реализует методы репозитория профиля пользователя.
/// </summary>
public sealed class ProfileRepository : IProfileRepository
{
    private readonly PostgreDbContext _dbContext;

    public ProfileRepository(PostgreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Метод получит информацию для профиля пользователя при входе после регитсрации.
    /// </summary>
    /// <returns>Данные о профиле.</returns>
    public async Task<ProfileInfoOutput> GetProfileInfoAsync()
    {
        try
        {
            var result = await _dbContext.ProfileInfos
                .Select(p => new ProfileInfoOutput
                {
                    ProfileInfoTitle = p.ProfileInfoTitle,
                    ProfileInfoText = p.ProfileInfoText,
                    IsVisibleInfo = p.IsVisibleInfo
                })
                .FirstOrDefaultAsync();

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
    /// </summary>
    /// <param name="roleId">Id роли.</param>
    /// <returns>Список элементов меню.</returns>
    public async Task<ProfileMenuItemResult> GetProfileMenuItemsAsync(int roleId)
    {
        try
        {
            var items = await _dbContext.ProfileMenuItems
                .Where(i => i.RoleId == roleId && !new[] { -1, 0 }.Contains(roleId))
                .Select(i => new ProfileMenuItemResult
                {
                    ProfileLeftMenuItems = _dbContext.ProfileMenuItems
                        .Where(a => a.MenuType == 1)
                        .Select(a => new ProfileMenuItemOutput
                        {
                            ProfileItemTitle = a.ProfileItemTitle,
                            Position = a.Position,
                            ProfileItemSysName = a.ProfileItemSysName,
                            ProfileItemUrl = a.ProfileItemUrl,
                            IsSelectItem = a.IsSelectItem,
                            IconUrl = a.IconUrl,
                            MenuType = a.MenuType,
                            IsVisibleBalance = a.IsVisibleBalance,
                            IsDropdown = a.IsDropdown
                        })
                        .OrderBy(o => o.Position)
                        .ToList(),
                    ProfileHeaderMenuItems = _dbContext.ProfileMenuItems
                        .Where(b => b.MenuType == 2)
                        .Select(b => new ProfileMenuItemOutput
                        {
                            ProfileItemTitle = b.ProfileItemTitle,
                            Position = b.Position,
                            ProfileItemSysName = b.ProfileItemSysName,
                            ProfileItemUrl = b.ProfileItemUrl,
                            IsSelectItem = b.IsSelectItem,
                            IconUrl = b.IconUrl,
                            MenuType = b.MenuType,
                            IsVisibleBalance = b.IsVisibleBalance,
                            IsDropdown = b.IsDropdown
                        })
                        .OrderBy(o => o.Position)
                        .ToList(),
                    ProfileDropdownMenuItems = _dbContext.ProfileMenuItems
                        .Where(c => c.MenuType == 3)
                        .Select(c => new ProfileMenuItemOutput
                        {
                            ProfileItemTitle = c.ProfileItemTitle,
                            Position = c.Position,
                            ProfileItemSysName = c.ProfileItemSysName,
                            ProfileItemUrl = c.ProfileItemUrl,
                            IsSelectItem = c.IsSelectItem,
                            IconUrl = c.IconUrl,
                            MenuType = c.MenuType,
                            IsVisibleBalance = c.IsVisibleBalance,
                            IsDropdown = c.IsDropdown
                        })
                        .OrderBy(o => o.Position)
                        .ToList()
                })
                .FirstOrDefaultAsync();

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
            var result = await _dbContext.ProfileItems
                .Select(i => new ProfileItemOutput
                {
                    ItemName = i.ItemName,
                    ItemSysName = i.ItemSysName,
                    ItemNumber = i.ItemNumber,
                    Position = i.Position
                })
                .OrderBy(o => o.Position)
                .ToListAsync();

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
            var result = await _dbContext.LessonsDuration
                .Select(l => new LessonDurationOutput
                {
                    DurationId = l.DurationId,
                    Time = l.Time,
                    Unit = l.Unit
                })
                .OrderBy(o => o.Time)
                .ToListAsync();

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
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список целей подготовки.</returns>
    public async Task<IEnumerable<PurposeTrainingOutput>> GetPurposeTrainingsAsync(long userId)
    {
        try
        {
            var result = await _dbContext.PurposeTrainings
                .Select(pt => new PurposeTrainingOutput
                {
                    PurposeId = pt.PurposeId,
                    PurposeSysName = pt.PurposeSysName,
                    PurposeName = pt.PurposeName
                })
                .ToListAsync();

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
    /// <param name="urlCertificates">Список путей к изображениям сертификатов.</param>
    /// <param name="urlAvatar">Путь к изображению профиля пользователя.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Выходная модель с изменениями.</returns>
    public async Task<MentorProfileInfoOutput> SaveProfileUserInfoAsync(MentorProfileInfoInput mentorProfileInfoInput, string[] urlCertificates, string urlAvatar, long userId)
    {
        try
        {
            // Добавит ФИО и контактные данные.
            await _dbContext.MentorProfileInfo.AddAsync(new MentorProfileInfoEntity
            {
                FirstName = mentorProfileInfoInput.FirstName,
                LastName = mentorProfileInfoInput.LastName,
                SecondName = mentorProfileInfoInput.SecondName,
                IsVisibleAllContact = mentorProfileInfoInput.IsVisibleAllContact,
                Email = mentorProfileInfoInput.Email,
                PhoneNumber = mentorProfileInfoInput.PhoneNumber,
                ProfileIconUrl = urlAvatar,
                FullName = mentorProfileInfoInput.FirstName 
                           + " " + mentorProfileInfoInput.LastName 
                           + " " + mentorProfileInfoInput.SecondName,
                UserId = userId
            });
            await _dbContext.SaveChangesAsync();

            var mapper = AutoFac.Resolve<IMapper>();

            // Добавит список предметов.
            var mentorItems = mapper.Map<List<MentorProfileItemEntity>>(mentorProfileInfoInput.MentorItems);
            var i = 0;
            
            foreach (var item in mentorItems)
            {
                if (i == 0)
                {
                    i = 1;
                }
                
                item.UserId = userId;
                item.Position = i;
                i++;
            }
            
            await _dbContext.MentorProfileItems.AddRangeAsync(mentorItems);
            await _dbContext.SaveChangesAsync();
            
            // Добавит список цен преподавателя.
            var mentorPrices = mapper.Map<List<MentorLessonPriceEntity>>(mentorProfileInfoInput.MentorPrices);
            
            foreach (var item in mentorPrices)
            {
                item.UserId = userId;
            }
            
            await _dbContext.MentorLessonPrices.AddRangeAsync(mentorPrices);
            await _dbContext.SaveChangesAsync();
            
            // Добавит длительности занятий преподавателя.
            var mentorDurations = mapper.Map<List<MentorLessonDurationEntity>>(mentorProfileInfoInput.MentorDurations);
            
            foreach (var item in mentorDurations)
            {
                item.UserId = userId;
            }
            
            await _dbContext.MentorLessonDurations.AddRangeAsync(mentorDurations);
            await _dbContext.SaveChangesAsync();
            
            // Добавит время занятий преподавателя.
            var mentorTimes = mapper.Map<List<MentorTimeEntity>>(mentorProfileInfoInput.MentorTimes);
            
            foreach (var item in mentorTimes)
            {
                item.UserId = userId;
                
                // TODO: доработать!
                // Получит Id дня.
            }
            
            await _dbContext.MentorTimes.AddRangeAsync(mentorTimes);
            await _dbContext.SaveChangesAsync();
            
            // Добавит цели подготовки.
            var mentorTrainings = mapper.Map<List<MentorTrainingEntity>>(mentorProfileInfoInput.MentorTrainings);
            
            foreach (var item in mentorTrainings)
            {
                item.UserId = userId;
                
                // Запишет Id цели подготовки.
                item.PurposeId = await _dbContext.PurposeTrainings
                    .Where(p => p.PurposeId == item.PurposeId)
                    .Select(p => p.PurposeId)
                    .FirstOrDefaultAsync();
            }
            
            await _dbContext.MentorTrainings.AddRangeAsync(mentorTrainings);
            await _dbContext.SaveChangesAsync();
            
            // Добавит опыт преподавателя.
            var mentorExperience = mapper.Map<List<MentorExperienceEntity>>(mentorProfileInfoInput.MentorExperience);
            
            foreach (var item in mentorExperience)
            {
                item.UserId = userId;
            }
            
            await _dbContext.MentorExperience.AddRangeAsync(mentorExperience);
            await _dbContext.SaveChangesAsync();
            
            // Добавит образование преподавателя.
            var mentorEducations = mapper.Map<List<MentorEducationEntity>>(mentorProfileInfoInput.MentorEducations);
            
            foreach (var item in mentorEducations)
            {
                item.UserId = userId;
            }
            
            await _dbContext.MentorEducations.AddRangeAsync(mentorEducations);
            await _dbContext.SaveChangesAsync();
            
            // Добавит информацию о преподавателе.
            var mentorAboutInfo = mapper.Map<List<MentorAboutInfoEntity>>(mentorProfileInfoInput.MentorAboutInfo);
            
            foreach (var item in mentorAboutInfo)
            {
                item.UserId = userId;
            }
            
            await _dbContext.MentorAboutInfos.AddRangeAsync(mentorAboutInfo);
            await _dbContext.SaveChangesAsync();
            
            // Запишет пути к сертификатам.
            var certificatesList = new List<MentorCertificateEntity>();
            
            foreach (var item in urlCertificates)
            {
                certificatesList.Add(new MentorCertificateEntity
                {
                    CertificateName = item,
                    UserId = userId
                });
            }

            await _dbContext.MentorCertificates.AddRangeAsync(certificatesList);
            await _dbContext.SaveChangesAsync();

            var result = mapper.Map<MentorProfileInfoOutput>(mentorProfileInfoInput);

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
            var result = await _dbContext.DaysWeek
                .Select(d => new DayWeekOutput
                {
                    DayName = d.DayName,
                    DaySysName = d.DaySysName,
                    Position = d.Position
                })
                .OrderBy(o => o.Position)
                .ToListAsync();

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
    /// Метод получит список сертификатов пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список сертификатов.</returns>
    public async Task<string[]> GetUserCertsAsync(long userId)
    {
        try
        {
            var result = await _dbContext.MentorCertificates
                .Where(c => c.UserId == userId)
                .Select(c => c.CertificateName)
                .ToArrayAsync();

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
    /// <param name="account">.</param>
    /// <returns>Аватар профиля пользователя.</returns>
    public async Task<string> GetProfileAvatarAsync(string account)
    {
        try
        {
            var result = await _dbContext.MentorProfileInfo
                .Where(u => u.Email.Equals(account))
                .Select(u => u.ProfileIconUrl)
                .FirstOrDefaultAsync();

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
    /// <param name="userId">Id пользователя.</param>
    /// <param name="roleId">Id роли пользователя.</param>
    /// <returns>Данные анкеты пользователя.</returns>
    public async Task<WorksheetOutput> GetProfileWorkSheetAsync(long userId, int roleId)
    {
        try
        {
            var result = new WorksheetOutput();

            // Если преподаватель.
            if (roleId == 2)
            {
                // Получит основную информацию анкеты.
                var userInfo = await _dbContext.MentorProfileInfo
                    .Where(pi => pi.UserId == userId)
                    .Select(pi => new WorksheetOutput
                    {
                        FirstName = pi.FirstName,
                        LastName = pi.LastName,
                        SecondName = pi.SecondName,
                        Email = pi.Email,
                        PhoneNumber = pi.PhoneNumber,
                        IsVisibleAllContact = pi.IsVisibleAllContact
                    })
                    .FirstOrDefaultAsync();

                // Если есть основная информация анкеты.
                if (userInfo is not null)
                {
                    result.FirstName = userInfo.FirstName;
                    result.LastName = userInfo.LastName;
                    result.SecondName = userInfo.SecondName;
                    result.Email = userInfo.Email;
                    result.PhoneNumber = userInfo.PhoneNumber;
                    result.IsVisibleAllContact = userInfo.IsVisibleAllContact;
                }

                // Получит предметы преподавателя.
                var mentorProfileItems = await (from mpi in _dbContext.MentorProfileItems
                        join pi in _dbContext.ProfileItems
                            on mpi.ItemNumber
                            equals pi.ItemNumber
                        where mpi.UserId == userId
                        select new ProfileItemOutput
                        {
                            ItemName = pi.ItemName,
                            ItemSysName = pi.ItemSysName,
                            Position = pi.Position,
                            ItemNumber = pi.ItemNumber
                        })
                    .ToArrayAsync();

                // Если есть предметы преподавателя.
                if (mentorProfileItems.Any())
                {
                    result.MentorItems.AddRange(mentorProfileItems);
                }
                
                // Получит цены преподавателя.
                var mentorLessonPrices = await _dbContext.MentorLessonPrices
                    .Where(p => p.UserId == userId)
                    .Select(p => new MentorProfilePrices
                    {
                        Price = p.Price,
                        Unit = p.Unit
                    })
                    .ToArrayAsync();

                // Если есть цены.
                if (mentorLessonPrices.Any())
                {
                    result.MentorPrices.AddRange(mentorLessonPrices);
                }
                
                // Получит длительности.
                var mentorLessonDurations = await _dbContext.MentorLessonDurations
                    .Where(d => d.UserId == userId)
                    .Select(d => new MentorProfileDurations
                    {
                        Time = d.Time,
                        Unit = d.Unit
                    })
                    .ToArrayAsync();
                
                // Если есть длительности.
                if (mentorLessonDurations.Any())
                {
                    result.MentorDurations.AddRange(mentorLessonDurations);
                }
                
                // Получит время.
                var times = await _dbContext.MentorTimes
                    .Where(t => t.UserId == userId)
                    .Select(t => new MentorTimes
                    {
                        TimeStart = t.TimeStart,
                        TimeEnd = t.TimeEnd,
                        DayName = _dbContext.DaysWeek
                            .Where(d => d.DayId == t.DayId)
                            .Select(d => d.DayName)
                            .FirstOrDefault()
                    })
                    .ToArrayAsync();
                
                // Если есть время.
                if (times.Any())
                {
                    result.MentorTimes.AddRange(times);
                }
                
                // Получит цели подготовки с подсвеченными (выбранными ранее).
                var mentorTrainings = await _dbContext.PurposeTrainings
                    .Select(pt => new PurposeTrainingOutput
                    {
                        PurposeName = pt.PurposeName,
                        PurposeSysName = pt.PurposeSysName,
                        PurposeId = pt.PurposeId,
                        IsSelected = _dbContext.MentorTrainings.Any(mt => mt.PurposeId == pt.PurposeId)
                    })
                    .ToArrayAsync();
                
                // Если есть цели.
                if (mentorTrainings.Any())
                {
                    result.MentorTrainings.AddRange(mentorTrainings);
                }
                
                // Получит опыт.
                var mentorExperience = await _dbContext.MentorExperience
                    .Where(e => e.UserId == userId)
                    .Select(e => new MentorExperience
                    {
                        ExperienceText = e.ExperienceText
                    })
                    .ToArrayAsync();
                
                // Если есть опыт.
                if (mentorExperience.Any())
                {
                    result.MentorExperience.AddRange(mentorExperience);
                }
                
                // Получит образование.
                var mentorEducations = await _dbContext.MentorEducations
                    .Where(e => e.UserId == userId)
                    .Select(e => new MentorEducations
                    {
                        EducationText = e.EducationText
                    })
                    .ToArrayAsync();
                
                // Если есть образование.
                if (mentorEducations.Any())
                {
                    result.MentorEducations.AddRange(mentorEducations);
                }
                
                // Получит информацию.
                var mentorAboutInfo = await _dbContext.MentorAboutInfos
                    .Where(a => a.UserId == userId)
                    .Select(a => new MentorAboutInfo
                    {
                        AboutInfoText = a.AboutInfoText
                    })
                    .ToArrayAsync();
                
                // Если есть информация.
                if (mentorAboutInfo.Any())
                {
                    result.MentorAboutInfo.AddRange(mentorAboutInfo);
                }
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
    /// Метод получит старое название аватара пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="roleId">Id роли.</param>
    /// <returns>Название аватара.</returns>
    public async Task<string> GetOldAvatatName(long userId, int roleId)
    {
        try
        {
            var result = string.Empty;
            
            // Если нужно получить название аватара преподавателя.
            if (roleId == 2)
            {
                result = await _dbContext.MentorProfileInfo
                    .Where(i => i.UserId == userId)
                    .Select(i => i.ProfileIconUrl)
                    .FirstOrDefaultAsync();
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
    /// Метод обновит название аватара пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="roleId">Id роли.</param>
    /// <param name="avatarName">Название аватара.</param>
    public async Task UpdateAvatatName(long userId, int roleId, string avatarName)
    {
        try
        {
            // Если нужно обновить название аватара преподавателя.
            if (roleId == 2)
            {
                var info = await _dbContext.MentorProfileInfo
                    .Where(i => i.UserId == userId)
                    .FirstOrDefaultAsync();

                if (info is not null)
                {
                    info.ProfileIconUrl = avatarName;
                    await _dbContext.SaveChangesAsync();
                }
            }
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
    /// <param name="userId">Id пользователя.</param>
    /// <param name="roleId">Роль пользователя.</param>
    /// <returns>Измененные данные.</returns>
    public async Task<MentorProfileInfoOutput> UpdateUserFioAsync(string firstName, string lastName, string secondName, long userId, int roleId)
    {
        try
        {
            var result = new MentorProfileInfoOutput();
            
            // Если нужно обновить фио преподавателя.
            if (roleId == 2)
            {
                var info = await _dbContext.MentorProfileInfo
                    .Where(i => i.UserId == userId)
                    .FirstOrDefaultAsync();

                if (info is not null)
                {
                    info.FirstName = firstName;
                    info.LastName = lastName;
                    info.SecondName = secondName;
                    await _dbContext.SaveChangesAsync();
                }

                result = new MentorProfileInfoOutput
                {
                    FirstName = firstName,
                    LastName = lastName,
                    SecondName = secondName
                };
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
    /// Метод обновит контактные данные пользователя.
    /// </summary>
    /// <param name="isVisibleContacts">Флаг видимости контактов.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="email">Почта.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="roleId">Роль пользователя.</param>
    /// <returns>Измененные данные.</returns>
    public async Task<MentorProfileInfoOutput> UpdateUserContactsAsync(bool isVisibleContacts, string phoneNumber, string email, long userId, int roleId)
    {
        try
        {
            var result = new MentorProfileInfoOutput();
            
            // Если нужно обновить контактные данные преподавателя.
            if (roleId == 2)
            {
                var info = await _dbContext.MentorProfileInfo
                    .Where(i => i.UserId == userId)
                    .FirstOrDefaultAsync();

                if (info is not null)
                {
                    info.Email = email;
                    info.IsVisibleAllContact = isVisibleContacts;
                    info.PhoneNumber = phoneNumber;
                    await _dbContext.SaveChangesAsync();
                }

                result = new MentorProfileInfoOutput
                {
                    Email = email,
                    PhoneNumber = phoneNumber,
                    IsVisibleAllContact = isVisibleContacts
                };
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
    /// Метод получит список предметов преподавателя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список предметов.</returns>
    public async Task<WorksheetOutput> GetMentorItemsAsync(long userId)
    {
        try
        {
            var result = new WorksheetOutput
            {
                MentorItems = await _dbContext.MentorProfileItems
                    .Where(i => i.UserId == userId)
                    .Select(i => new ProfileItemOutput
                    {
                        ItemId = (int)i.ItemId,
                        ItemNumber = i.ItemNumber,
                        Position = i.Position
                    })
                    .ToListAsync()
            };

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
    /// <returns>Обновленный список предметов.</returns>
    public async Task UpdateMentorItemsAsync(List<MentorProfileItemEntity> updateItems)
    {
        try
        {
            _dbContext.MentorProfileItems.UpdateRange(updateItems);
            await _dbContext.SaveChangesAsync();
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод обновит список цен преподавателя в анкете.
    /// </summary>
    /// <param name="updateItems">Список предметов для обновления.</param>
    /// <returns>Обновленный список предметов.</returns>
    public async Task UpdateMentorPricesAsync(List<MentorLessonPriceEntity> updateItems)
    {
        try
        {
            _dbContext.MentorLessonPrices.UpdateRange(updateItems);
            await _dbContext.SaveChangesAsync();
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит список цен преподавателя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список цен.</returns>
    public async Task<WorksheetOutput> GetMentorPricesAsync(long userId)
    {
        try
        {
            var result = new WorksheetOutput
            {
                MentorPrices = await _dbContext.MentorLessonPrices
                    .Where(p => p.UserId == userId)
                    .Select(p => new MentorProfilePrices
                    {
                        Price = p.Price,
                        Unit = p.Unit,
                        PriceId = p.PriceId
                    })
                    .ToListAsync()
            };

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
    /// Метод получит список длительностей преподавателя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список длительностей.</returns>
    public async Task<WorksheetOutput> GetMentorDurationsAsync(long userId)
    {
        try
        {
            var result = new WorksheetOutput
            {
                MentorDurations = await _dbContext.MentorLessonDurations
                    .Where(d => d.UserId == userId)
                    .Select(d => new MentorProfileDurations
                    {
                        Time = d.Time,
                        Unit = d.Unit,
                        DurationId = d.DurationId
                    })
                    .ToListAsync()
            };

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
    /// <param name="updateItems">Список длительностей для обновления.</param>
    /// <returns>Обновленный список длительностей.</returns>
    public async Task UpdateMentorDurationsAsync(List<MentorLessonDurationEntity> updateDurations)
    {
        try
        {
            _dbContext.MentorLessonDurations.UpdateRange(updateDurations);
            await _dbContext.SaveChangesAsync();
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит список времен преподавателя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список времен.</returns>
    public async Task<WorksheetOutput> GetMentorTimesAsync(long userId)
    {
        try
        {
            var result = new WorksheetOutput
            {
                MentorTimes = await _dbContext.MentorTimes
                    .Where(d => d.UserId == userId)
                    .Select(d => new MentorTimes
                    {
                        TimeStart = d.TimeStart,
                        TimeEnd = d.TimeEnd,
                        DaySysName = _dbContext.DaysWeek
                            .Where(dw => dw.DayId == d.DayId)
                            .Select(dw => dw.DaySysName)
                            .FirstOrDefault(),
                        TimeId = d.TimeId
                    })
                    .ToListAsync()
            };

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
    /// Метод обновит время преподавателя в анкете.
    /// </summary>
    /// <param name="updateTimes">Список времени для обновления.</param>
    /// <returns>Обновленный список длительностей.</returns>
    public async Task UpdateMentorTimesAsync(List<MentorTimeEntity> updateTimes)
    {
        try
        {
            _dbContext.MentorTimes.UpdateRange(updateTimes);
            await _dbContext.SaveChangesAsync();
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
    public async Task UpdateMentorAboutAsync(List<MentorAboutInfoEntity> updateAboutInfo)
    {
        try
        {
            _dbContext.UpdateRange(updateAboutInfo);
            await _dbContext.SaveChangesAsync();
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит Id дня по его системному названию.
    /// </summary>
    /// <param name="sysName">Системное название.</param>
    /// <returns>Id дня.</returns>
    public async Task<int> GetDayIdBySysNameAsync(string sysName)
    {
        try
        {
            var result = await _dbContext.DaysWeek
                .Where(d => d.DaySysName.Equals(sysName))
                .Select(d => d.DayId)
                .FirstOrDefaultAsync();

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
    /// Метод получит данные о себе преподавателя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные о себе.</returns>
    public async Task<WorksheetOutput> GetMentorAboutInfoAsync(long userId)
    {
        try
        {
            var result = new WorksheetOutput
            {
                MentorAboutInfo = await _dbContext.MentorAboutInfos
                    .Where(a => a.UserId == userId)
                    .Select(a => new MentorAboutInfo
                    {
                        AboutInfoText = a.AboutInfoText
                    })
                    .ToListAsync()
            };

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