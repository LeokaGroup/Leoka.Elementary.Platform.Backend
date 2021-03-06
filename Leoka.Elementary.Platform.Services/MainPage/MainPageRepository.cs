using Leoka.Elementary.Platform.Abstractions.MainPage;
using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Models.Common.Output;
using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Leoka.Elementary.Platform.Models.MainPage.Output;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.Services.MainPage;

/// <summary>
/// Класс реализует методы репозитория главной страницы.
/// </summary>
public class MainPageRepository : IMainPageRepository
{
    private readonly PostgreDbContext _dbContext;

    public MainPageRepository(PostgreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Метод получит список полей хидера.
    /// </summary>
    /// <returns>Список полей хидера.</returns>
    public async Task<IEnumerable<HeaderOutput>> GetHeaderItemsAsync()
    {
        try
        {
            var result = await _dbContext.Header
                .Select(h => new HeaderOutput
                {
                    HeaderActionSysName = h.HeaderActionSysName,
                    HeaderItem = h.HeaderItem,
                    HeaderItemPosition = h.HeaderItemPosition,
                    HeaderItemUrl = h.HeaderItemUrl
                })
                .OrderBy(o => o.HeaderItemPosition)
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
    /// Метод получит список полей футера.
    /// </summary>
    /// <returns>Список полей футера.</returns>
    public async Task<IEnumerable<FooterOutput>> GetFooterItemsAsync()
    {
        try
        {
            var result = await _dbContext.Footer
                .Select(f => new FooterOutput
                {
                    FirstFooterTitle = f.FirstFooterTitle,
                    LastFooterTitle = f.LastFooterTitle,
                    FooterColumnNumber = f.FooterColumnNumber,
                    FooterItemActionSysName = f.FooterItemActionSysName,
                    FooterItemPosition = f.FooterItemPosition,
                    FooterItemText = f.FooterItemText,
                    FooterItemUrl = f.FooterItemUrl,
                    FooterTelegramUrl = f.FooterTelegramUrl,
                    FooterTelegramActionSysName = f.FooterTelegramActionSysName,
                    FooterVkActionSysName = f.FooterVkActionSysName,
                    FooterVkUrl = f.FooterVkUrl,
                    FooterWhatsAppUrl = f.FooterWhatsAppUrl,
                    FooterWhatsAppActionSysName = f.FooterWhatsAppActionSysName
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
    /// Метод получит данные для фона студента.
    /// </summary>
    /// <returns>Данные для фона студента.</returns>
    public async Task<MainFonStudentOutput> GetMainFonStudentAsync()
    {
        try
        {
            var result = await _dbContext.MainFonStudent
                .Where(f => f.FonSubTitleId == 1)
                .Select(f => new MainFonStudentOutput
                {
                    FonTitle = f.FonTitle,
                    FonSubTitle = f.FonSubTitle,
                    FonSubTitleId = f.FonSubTitleId,
                    MainFonStudentItems = new List<MainFonStudentItemsOutput>(_dbContext.MainFonStudentItems
                            .Where(i => i.FonSubTitleId == 1)
                            .Select(i => new MainFonStudentItemsOutput
                            {
                                FonSubTitleId = i.FonSubTitleId,
                                FonSubTitleText = i.FonSubTitleText
                            }))
                        .ToList()
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
    /// Метод получит данные записи на урок.
    /// <param name="typeRole">Тип роли.
    /// 1 - для главной страницы ученика.
    /// 2 - для главной страницы преподавателя.</param>
    /// </summary>
    /// <returns>Данные записи на урок.</returns>
    public async Task<ReceptionOutput> GetReceptionAsync(int typeRole)
    {
        try
        {
            var result = await _dbContext.WriteReception
                .Where(r => r.TypeRole == typeRole)
                .Select(r => new ReceptionOutput
                {
                    WriteReceptionText = r.WriteReceptionText,
                    WriteReceptionButtonText = r.WriteReceptionButtonText
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
    /// Метод получит данные блока с чего начать.
    /// </summary>
    /// <param name="typeRole">Тип роли.</param>
    /// <returns>Данные блока.</returns>
    public async Task<BeginOutput> GetBeginItemsAsync(int typeRole)
    {
        try
        {
            var result = await _dbContext.WhereBegin
                .Select(w => new BeginOutput
                {
                    WhereBeginTitle = w.WhereBeginTitle,
                    WhereBeginSubTitle = w.WhereBeginSubTitle,
                    WhereBeginItems = _dbContext.WhereBeginItems
                        .Where(i => i.TypeRole == typeRole)
                        .Select(i => new BeginItemsOutput
                        {
                            BeginUrlIcon = i.BeginUrlIcon,
                            BeginTitle = i.BeginTitle,
                            BeginSubTitle = i.BeginSubTitle
                        })
                        .ToList()
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
    /// Метод получит данные для блока умного класса.
    /// </summary>
    /// <param name="typeRole">Тип роли.</param>
    /// <returns>Данные для блока.</returns>
    public async Task<SmartClassStudentOutput> GetSmartClassAsync(int typeRole)
    {
        try
        {
            var result = await (from s in _dbContext.SmartClassStudent
                    select new SmartClassStudentOutput
                    {
                        SmartClassTitle = s.SmartClassTitle,
                        SmartClassSubTitle = s.SmartClassSubTitle,
                        SmartClassUrlPreview = s.SmartClassUrlPreview,
                        SmartClassStudentItems = new List<SmartClassStudentItemsOutput>(_dbContext.SmartClassStudentItems
                                .Where(sc => sc.TypeRole == typeRole)
                                .Select(sc => new SmartClassStudentItemsOutput
                                {
                                    SmartItemTitle = sc.SmartItemTitle,
                                    SmartItemSubTitle = sc.SmartItemSubTitle
                                }))
                            .ToList()
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
    /// Метод получит данные для блока вопросов.
    /// </summary>
    /// <returns>Список вопросов с вариантами ответов.</returns>
    public async Task<IEnumerable<MainBestQuestionEntity>> GetBestQuestionsAsync()
    {
        try
        {
            var result = await _dbContext.MainBestQuestions
                .Include(b => b.MainBestOptions)
                .Select(b => new MainBestQuestionEntity
                {
                    MainBestOptionBlockId = b.MainBestOptionBlockId,
                    QuestionId = b.QuestionId,
                    MainBestOptionQuestionText = b.MainBestOptionQuestionText,
                    MainBestOptions = b.MainBestOptions
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
    /// Метод получит данные для заголовков блока списка вопросов.
    /// </summary>
    /// <returns>Данные для заголовков блока списка вопросов.</returns>
    public async Task<MainBestOptionEntity> GetTitleOptionAsync()
    {
        try
        {
            var result = await _dbContext.MainBestOptions
                .Select(b => new MainBestOptionEntity
                {
                    BestOptionTitle = b.BestOptionTitle,
                    BestOptionSubTitle = b.BestOptionSubTitle,
                    BestOptionButtonText = b.BestOptionButtonText
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
    /// Метод получит данные для блока о нашей платформе.
    /// </summary>
    /// <returns>Данные блока.</returns>
    public async Task<AboutOutput> GetAboutAsync()
    {
        try
        {
            var result = await _dbContext.AboutPlatforms
                .Select(a => new AboutOutput
                {
                    AboutTitle = a.AboutTitle,
                    AboutSubTitle = a.AboutSubTitle,
                    AboutMentorTitle = a.AboutMentorTitle,
                    AboutMentorSubTitle = a.AboutMentorSubTitle,
                    AboutStudentTitle = a.AboutStudentTitle,
                    AboutStudentSubTitle = a.AboutStudentSubTitle,
                    UrlIconMentor = a.UrlIconMentor,
                    UrlIconStudent = a.UrlIconStudent
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
    /// Метод получит данные для блока создания заявки.
    /// </summary>
    /// <returns>Данные блока.</returns>
    public async Task<RequestOutput> GetRequestAsync()
    {
        try
        {
            var result = await _dbContext.Requests
                .Select(r => new RequestOutput
                {
                    RequestFirstName = r.RequestFirstName,
                    RequestLastName = r.RequestLastName,
                    RequestPhoneNumber = r.RequestPhoneNumber,
                    RequestTitle = r.RequestTitle,
                    RequestSubTitle = r.RequestSubTitle,
                    RequestButtonText = r.RequestButtonText,
                    RequestEmail = r.RequestEmail,
                    RequestMessage = r.RequestMessage
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
    /// Метод получит данные блока преподавателя.
    /// </summary>
    /// <returns>Данные блока.</returns>
    public async Task<MentorOutput> GetMentorAsync()
    {
        try
        {
            var result = await _dbContext.MentorWork
                .Select(m => new MentorOutput
                {
                    MentorWorkButtonText = m.MentorWorkButtonText,
                    MentorWorkTitle = m.MentorWorkTitle,
                    MentorWorkSubTitle = m.MentorWorkSubTitle,
                    MentorWorkUrl = m.MentorWorkUrl,
                    UrlIconMentor = m.UrlIconMentor
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
    /// Метод получит данные для блока преподавателя на главной странице преподавателя.
    /// </summary>
    /// <returns>Данные блока преподавателя.</returns>
    public async Task<MainMentorOutput> GetMainMentorAsync()
    {
        try
        {
            var result = await _dbContext.MainFonMentor
                .Select(mf => new MainMentorOutput
                {
                    FonTitle = mf.FonTitle,
                    FonSubTitle = mf.FonSubTitle,
                    MainMentorItems = _dbContext.MainFonMentorItems
                        .Select(mi => new MainMentorItemOutput
                        {
                            FonSubTitleTextFirst = mi.FonSubTitleTextFirst,
                            FonSubTitleTextSecond = mi.FonSubTitleTextSecond,
                            FonSubSecondNumber = mi.FonSubSecondNumber
                        })
                        .OrderBy(o => o.FonSubSecondNumber)
                        .ToList()
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
}