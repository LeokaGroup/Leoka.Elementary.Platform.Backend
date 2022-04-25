using AutoMapper;
using Leoka.Elementary.Platform.Abstractions.MainPage;
using Leoka.Elementary.Platform.Models.Common.Output;
using Leoka.Elementary.Platform.Models.MainPage.Output;

namespace Leoka.Elementary.Platform.Services.MainPage;

/// <summary>
/// Класс реализует методы сервиса главной страницы.
/// </summary>
public class MainPageService : IMainPageService
{
    private readonly IMainPageRepository _mainPageRepository;
    private readonly IMapper _mapper;
    
    public MainPageService(IMainPageRepository mainPageRepository,
        IMapper mapper)
    {
        _mainPageRepository = mainPageRepository;
        _mapper = mapper;
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

    /// <summary>
    /// Метод получит данные для фона студента.
    /// </summary>
    /// <returns>Данные для фона студента.</returns>
    public async Task<MainFonStudentOutput> GetMainFonStudentAsync()
    {
        try
        {
            var result = await _mainPageRepository.GetMainFonStudentAsync();

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
    /// </summary>
    /// <returns>Данные записи на урок.</returns>
    public async Task<ReceptionOutput> GetReceptionAsync()
    {
        try
        {
            var result = await _mainPageRepository.GetReceptionAsync();

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
    /// </summary>
    /// <returns>Данные записи на урок.</returns>
    public async Task<BeginOutput> GetBeginItemsAsync()
    {
        try
        {
            var items = await _mainPageRepository.GetBeginItemsAsync();
            
            // Мапит к типу BeginOutput.
            var result = _mapper.Map<BeginOutput>(items);

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
    /// <returns>Данные для блока.</returns>
    public async Task<SmartClassStudentOutput> GetSmartClassAsync()
    {
        try
        {
            var result = await _mainPageRepository.GetSmartClassAsync();

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
    public async Task<IEnumerable<BestQuestionOutput>> GetBestQuestionsAsync()
    {
        try
        {
            var items = await _mainPageRepository.GetBestQuestionsAsync();

            var result = _mapper.Map<List<BestQuestionOutput>>(items);

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
    public async Task<OptionOutput> GetTitleOptionAsync()
    {
        try
        {
            var items = await _mainPageRepository.GetTitleOptionAsync();

            var result = _mapper.Map<OptionOutput>(items);

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
            var result = await _mainPageRepository.GetAboutAsync();

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
            var result = await _mainPageRepository.GetRequestAsync();

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
            var result = await _mainPageRepository.GetMentorAsync();

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