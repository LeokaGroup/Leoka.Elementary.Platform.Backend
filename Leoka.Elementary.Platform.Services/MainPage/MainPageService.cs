using Leoka.Elementary.Platform.Abstractions.MainPage;
using Leoka.Elementary.Platform.Models.Common.Output;

namespace Leoka.Elementary.Platform.Services.MainPage;

/// <summary>
/// Класс реализует методы сервиса главной страницы.
/// </summary>
public class MainPageService : IMainPageService
{
    private readonly IMainPageRepository _mainPageRepository;
    
    public MainPageService(IMainPageRepository mainPageRepository)
    {
        _mainPageRepository = mainPageRepository;
    }

    /// <summary>
    /// Метод получит список полей хидера.
    /// </summary>
    /// <returns>Список полей хидера.</returns>
    public async Task<IEnumerable<HeaderOutput>> GetHeaderItemsAsync()
    {
        try
        {
            var result = await _mainPageRepository.GetHeaderItemsAsync();

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
    /// Метод получит список полей хидера.
    /// </summary>
    /// <returns>Список полей хидера.</returns>
    public async Task<IEnumerable<FooterOutput>> GetFooterItemsAsync()
    {
        try
        {
            var result = await _mainPageRepository.GetFooterItemsAsync();

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