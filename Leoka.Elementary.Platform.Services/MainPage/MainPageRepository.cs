using Leoka.Elementary.Platform.Abstractions.MainPage;
using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Models.Common.Output;
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
    public async Task<IEnumerable<MainFonStudentOutput>> GetMainFonStudentAsync()
    {
        try
        {
            var result = await (from m1 in _dbContext.MainFonStudent
                    from m2 in _dbContext.MainFonStudentItems
                    where m1.FonSubTitleId == 1
                    select new MainFonStudentOutput
                    {
                        FonTitle = m1.FonTitle,
                        FonSubTitle = m1.FonSubTitle,
                        FonSubTitleId = m1.FonSubTitleId,
                        MainFonStudentItems = new List<MainFonStudentItemsOutput>
                        {
                            new()
                            {
                                FonSubTitleId = m2.FonSubTitleId,
                                FonSubTitleText = m2.FonSubTitleText
                            }
                        }
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
}