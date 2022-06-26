﻿using AutoMapper;
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
                        .Where(a => a.MenuType == 1 && a.RoleId == roleId)
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
    public async Task<MentorProfileInfoOutput> SaveProfileUserInfoAsync(MentorProfileInfoInput mentorProfileInfoInput,
        string[] urlCertificates, string urlAvatar, long userId)
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
            var userTimes = mapper.Map<List<UserTimeEntity>>(mentorProfileInfoInput.UserTimes);

            foreach (var item in userTimes)
            {
                item.UserId = userId;

                // TODO: доработать!
                // Получит Id дня.
            }

            await _dbContext.UserTimes.AddRangeAsync(userTimes);
            await _dbContext.SaveChangesAsync();

            // Добавит цели подготовки.
            var mentorTrainings = mapper.Map<List<UserTrainingEntity>>(mentorProfileInfoInput.UserTrainings);

            foreach (var item in mentorTrainings)
            {
                item.UserId = userId;

                // Запишет Id цели подготовки.
                item.PurposeId = await _dbContext.PurposeTrainings
                    .Where(p => p.PurposeId == item.PurposeId)
                    .Select(p => p.PurposeId)
                    .FirstOrDefaultAsync();
            }

            await _dbContext.UserTrainings.AddRangeAsync(mentorTrainings);
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

            var aboutIdx = 0;
            foreach (var item in mentorAboutInfo)
            {
                item.UserId = userId;
                item.Position = aboutIdx;
                aboutIdx++;
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
                    result.UserItems.AddRange(mentorProfileItems);
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
                var times = await _dbContext.UserTimes
                    .Where(t => t.UserId == userId)
                    .Select(t => new UserTimes
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
                    result.UserTimes.AddRange(times);
                }

                // Получит цели подготовки с подсвеченными (выбранными ранее).
                var userTrainings = await _dbContext.PurposeTrainings
                    .Select(pt => new PurposeTrainingOutput
                    {
                        PurposeName = pt.PurposeName,
                        PurposeSysName = pt.PurposeSysName,
                        PurposeId = pt.PurposeId,
                        IsSelected = _dbContext.UserTrainings.Any(mt => mt.PurposeId == pt.PurposeId)
                    })
                    .ToArrayAsync();

                // Если есть цели.
                if (userTrainings.Any())
                {
                    result.UserTrainings.AddRange(userTrainings);
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

            // Если учащийся.
            if (roleId == 1)
            {
                // Выбираем возрасты преподавателя для выбора.
                var mentorAge = await _dbContext.MentorAge
                    .Select(a => new MentorAgeOutput
                    {
                        AgeId = a.AgeId,
                        StartAge = a.StartAge,
                        EndAge = a.EndAge
                    })
                    .ToArrayAsync();

                // Если возраст есть.
                if (mentorAge.Any())
                {
                    result.MentorAge.AddRange(mentorAge);
                }

                // Выбираем пол преподавателей для выбора.
                var mentorGenders = await _dbContext.MentorGender
                    .Select(g => new MentorGenderOutput
                    {
                        GenderId = g.GenderId,
                        GenderName = g.GenderName
                    })
                    .ToArrayAsync();

                // Если пол есть.
                if (mentorGenders.Any())
                {
                    result.MentorGenders.AddRange(mentorGenders);
                }

                // Выбираем комментарии студента.
                var studentComments = await _dbContext.StudentComments
                    .Select(c => new StudentCommentsOutput
                    {
                        CommentId = c.CommentId,
                        UserId = c.UserId,
                        CommentText = c.CommentText
                    })
                    .FirstOrDefaultAsync();

                // Если есть комментарии
                if (studentComments is not null)
                {
                    result.StudentComments = studentComments;
                }

                // Получаем выбранный возраст преподавателя.
                var selectedMentorAge = await (from sam in _dbContext.StudentAgeMentor
                        join ma in _dbContext.MentorAge
                            on sam.MentorAge.AgeId
                            equals ma.AgeId
                        select new StudentAgeMentorOutput
                        {
                            MentorAge = new MentorAgeOutput
                            {
                                AgeId = sam.MentorAge.AgeId,
                                EndAge = ma.EndAge,
                                StartAge = ma.StartAge
                            },
                            StudentAgeMentorId = sam.StudentAgeMentorId,
                            UserId = sam.UserId
                        })
                    .FirstOrDefaultAsync();

                // Если студент выбирал возраст преподавателя ранее.
                if (selectedMentorAge is not null)
                {
                    result.StudentAgeMentor = selectedMentorAge;
                }

                // Получаем выбранный пол преподавателя.
                var selectedMentorGender = await (from sg in _dbContext.StudentGenderMentor
                        join mg in _dbContext.MentorGender
                            on sg.MentorGender.GenderId
                            equals mg.GenderId
                        select new StudentGenderMentorOutput
                        {
                            MentorGender = new MentorGenderOutput
                            {
                                GenderId = mg.GenderId,
                                GenderName = mg.GenderName
                            },
                            StudentGenderMentorId = sg.StudentGenderMentorId,
                            UserId = sg.UserId
                        })
                    .FirstOrDefaultAsync();

                // Если студент выбирал пол преподавателя ранее.
                if (selectedMentorGender is not null)
                {
                    result.StudentGenderMentor = selectedMentorGender;
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
    public async Task<MentorProfileInfoOutput> UpdateUserFioAsync(string firstName, string lastName, string secondName,
        long userId, int roleId)
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
    public async Task<MentorProfileInfoOutput> UpdateUserContactsAsync(bool isVisibleContacts, string phoneNumber,
        string email, long userId, int roleId)
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
    /// Метод получит список предметов пользователя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="roleId">Id роли пользователя.</param>
    /// <returns>Список предметов.</returns>
    public async Task<WorksheetOutput> GetUserItemsAsync(long userId, int roleId)
    {
        try
        {
            var result = new WorksheetOutput();

            // Если преподаватель.
            if (roleId == 2)
            {
                result = new WorksheetOutput
                {
                    UserItems = await _dbContext.MentorProfileItems
                        .Where(i => i.UserId == userId)
                        .Select(i => new ProfileItemOutput
                        {
                            ItemId = (int)i.ItemId,
                            ItemNumber = i.ItemNumber,
                            Position = i.Position
                        })
                        .ToListAsync()
                };
            }

            // Если студент.
            if (roleId == 1)
            {
                result = new WorksheetOutput
                {
                    UserItems = await _dbContext.StudentProfileItems
                        .Where(i => i.UserId == userId)
                        .Select(i => new ProfileItemOutput
                        {
                            ItemId = (int)i.ItemId,
                            ItemNumber = i.ItemNumber,
                            Position = i.Position
                        })
                        .ToListAsync()
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
    public async Task<WorksheetOutput> GetUserTimesAsync(long userId)
    {
        try
        {
            var result = new WorksheetOutput
            {
                UserTimes = await _dbContext.UserTimes
                    .Where(d => d.UserId == userId)
                    .Select(d => new UserTimes
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
    public async Task UpdateMentorTimesAsync(List<UserTimeEntity> updateTimes)
    {
        try
        {
            _dbContext.UserTimes.UpdateRange(updateTimes);
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
            _dbContext.MentorAboutInfos.UpdateRange(updateAboutInfo);
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
                        AboutInfoText = a.AboutInfoText,
                        AboutInfoId = a.AboutInfoId
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
    /// Метод получит данные об образовании преподавателя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные об образовании.</returns>
    public async Task<WorksheetOutput> GetMentorEducationsAsync(long userId)
    {
        try
        {
            var result = new WorksheetOutput
            {
                MentorEducations = await _dbContext.MentorEducations
                    .Where(e => e.UserId == userId)
                    .Select(e => new MentorEducations
                    {
                        EducationText = e.EducationText,
                        EducationId = e.EducationId
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
    /// Метод обновит данные об образовании преподавателя в анкете.
    /// </summary>
    /// <param name="updateAboutInfo">Список информации об образовании для обновления.</param>
    /// <returns>Обновленные данные об образовании.</returns>
    public async Task UpdateMentorEducationsAsync(List<MentorEducationEntity> updateEducations)
    {
        try
        {
            _dbContext.MentorEducations.UpdateRange(updateEducations);
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
    /// Метод получит данные об опыте преподавателя в анкете.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные об опыте.</returns>
    public async Task<WorksheetOutput> GetMentorExperienceAsync(long userId)
    {
        try
        {
            var result = new WorksheetOutput
            {
                MentorExperience = await _dbContext.MentorExperience
                    .Where(e => e.UserId == userId)
                    .Select(e => new MentorExperience
                    {
                        ExperienceText = e.ExperienceText,
                        ExperienceId = e.ExperienceId
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
    /// Метод обновит данные об опыте преподавателя в анкете.
    /// </summary>
    /// <param name="updateAboutInfo">Список информации об опыте для обновления.</param>
    /// <returns>Обновленные данные об опыте.</returns>
    public async Task UpdateMentorExperienceAsync(List<MentorExperienceEntity> updateExperience)
    {
        try
        {
            _dbContext.MentorExperience.UpdateRange(updateExperience);
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
    /// Метод добавляет изображения сертификатов пользователя.
    /// </summary>
    /// <param name="fileNames">Список названий изображений.</param>
    /// <param name="userId">Id пользователя.</param>
    public async Task AddProfileUserCertsAsync(string[] fileNames, long userId)
    {
        try
        {
            await _dbContext.MentorCertificates.AddRangeAsync(fileNames.Select(x => new MentorCertificateEntity
            {
                CertificateName = x,
                UserId = userId
            }));
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
    /// Метод добавляет запись информации о преподавателе по дефолту.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные анкеты.</returns>
    public async Task AddDefaultMentorAboutInfoAsync(long userId)
    {
        try
        {
            // Выбирает последние номера.
            var lastNumbers = await _dbContext.MentorAboutInfos
                .AsNoTracking()
                .Where(i => i.UserId == userId)
                .OrderByDescending(o => o.AboutInfoId)
                .Select(i => new
                {
                    i.Position,
                    i.UserId
                })
                .FirstOrDefaultAsync();

            if (lastNumbers is not null)
            {
                var lastPosition = lastNumbers.Position;

                await _dbContext.MentorAboutInfos.AddAsync(new MentorAboutInfoEntity
                {
                    Position = ++lastPosition,
                    UserId = lastNumbers.UserId,
                    AboutInfoText = string.Empty
                });
                await _dbContext.SaveChangesAsync();
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
    /// Метод добавляет запись информации об образовании по дефолту.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные анкеты.</returns>
    public async Task AddDefaultMentorEducationAsync(long userId)
    {
        try
        {
            // Выбирает последние номера.
            var lastNumbers = await _dbContext.MentorEducations
                .AsNoTracking()
                .Where(i => i.UserId == userId)
                .OrderByDescending(o => o.EducationId)
                .Select(i => new
                {
                    i.UserId
                })
                .FirstOrDefaultAsync();

            if (lastNumbers is not null)
            {
                await _dbContext.MentorEducations.AddAsync(new MentorEducationEntity
                {
                    UserId = lastNumbers.UserId,
                    EducationText = string.Empty
                });
                await _dbContext.SaveChangesAsync();
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
    /// Метод добавляет запись информации об опыте по дефолту.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Данные анкеты.</returns>
    public async Task AddDefaultMentorExperienceAsync(long userId)
    {
        try
        {
            // Выбирает последние номера.
            var lastNumbers = await _dbContext.MentorExperience
                .AsNoTracking()
                .Where(i => i.UserId == userId)
                .OrderByDescending(o => o.ExperienceId)
                .Select(i => new
                {
                    i.UserId
                })
                .FirstOrDefaultAsync();

            if (lastNumbers is not null)
            {
                await _dbContext.MentorExperience.AddAsync(new MentorExperienceEntity
                {
                    UserId = lastNumbers.UserId,
                    ExperienceText = string.Empty
                });
                await _dbContext.SaveChangesAsync();
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
    /// Метод добавляет новые предметы преподавателю.
    /// </summary>
    /// <param name="addItems">Список предметов для добавления.</param>
    /// <param name="userId">Id пользователя.</param>
    public async Task AddMentorItemsAsync(List<ProfileItemOutput> addItems, long userId)
    {
        try
        {
            // i = 1 Позиция по дефолту ставим 1.
            for (var i = 1; i < addItems.Count; i++)
            {
                await _dbContext.MentorProfileItems.AddAsync(new MentorProfileItemEntity
                {
                    UserId = userId,
                    Position = i,
                    ItemNumber = i
                });
            }

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
    /// Метод добавляет новые предметы ученика.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="addItems">Список предметов для добавления.</param>
    public async Task AddStudentItemsAsync(List<ProfileItemOutput> addItems, long userId)
    {
        try
        {
            // i = 1 Позиция по дефолту ставим 1.
            var pos = 1;
            
            foreach (var _ in addItems)
            {
                await _dbContext.StudentProfileItems.AddAsync(new StudentProfileItemEntity
                {
                    UserId = userId,
                    Position = pos,
                    ItemNumber = pos
                });

                pos++;
            }

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
    /// Метод обновит список предметов ученика в анкете.
    /// </summary>
    /// <param name="updateItems">Список предметов для обновления.</param>
    /// <returns>Обновленный список предметов.</returns>
    public async Task UpdateStudentItemsAsync(List<StudentProfileItemEntity> updateItems)
    {
        try
        {
            _dbContext.StudentProfileItems.UpdateRange(updateItems);
            await _dbContext.SaveChangesAsync();
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}