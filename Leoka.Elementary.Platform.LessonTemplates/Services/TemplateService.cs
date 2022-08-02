using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Core.Exceptions;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions;
using Leoka.Elementary.Platform.LessonTemplates.Exceptions;
using Leoka.Elementary.Platform.Models.Template.Output;

namespace Leoka.Elementary.Platform.LessonTemplates.Services;

/// <summary>
/// Класс реализует методы сервиса создания шаблонов урока.
/// </summary>
public sealed class TemplateService: ITemplateService
{
    private readonly ITemplateRepository _templateRepository;
    private readonly IUserRepository _userRepository;
    
    public TemplateService(ITemplateRepository templateRepository,
        IUserRepository userRepository)
    {
        _templateRepository = templateRepository;
        _userRepository = userRepository;
    }

    /// <summary>
    /// Метод получает шаблон урока.
    /// </summary>
    /// <param name="templateId">Id шаблона, который нужно создать.</param>
    /// <returns>Шаблон урока.</returns>
    public async Task<TemplateOutput> GetTemplateAsync(long templateId)
    {
        try
        {
            // Если не передали тип шаблона.
            if (templateId <= 0)
            {
                throw new EmptyTemplateTypeException(templateId);
            }
            
            var result = await _templateRepository.GetTemplateAsync(templateId);

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
    /// Метод получает список названий шаблонов в зависимости от переданного типа шаблона.
    /// <param name="idItemTemplate">Id предмета, шаблоны которого нужно получить.</param>
    /// </summary>
    /// <returns>Список названий шаблонов</returns>
    public async Task<IEnumerable<TemplateOutput>> GetTemplateNamesByTypeAsync(long idItemTemplate)
    {
        try
        {
            var result = await _templateRepository.GetTemplateNamesByTypeAsync(idItemTemplate);

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
    /// Метод получает список шаблонов уроков.
    /// </summary>
    /// <returns>Список шаблонов уроков.</returns>
    public async Task<IEnumerable<TemplateOutput>> GetItemTemplatesAsync()
    {
        try
        {
            var result = await _templateRepository.GetItemTemplatesAsync();

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
    /// Метод сохраняет шаблон урока.
    /// </summary>
    /// <param name="templateId">Id шаблона.</param>
    /// /// <param name="template">Шаблон (json).</param>
    public async Task SaveTemplateAsync(long templateId, string template, string account)
    {
        try
        {
            // Если не передали тип шаблона.
            if (templateId <= 0)
            {
                throw new EmptyTemplateTypeException(templateId);
            }

            // Если не передали шаблон предмета.
            if (string.IsNullOrEmpty(template))
            {
                throw new EmptyTemplateException(template);
            }

            // Находим пользователя.
            var user = await _userRepository.GetUserByEmailAsync(account);

            if (user is null)
            {
                throw new NotFoundUserException(account);
            }
            
            // Проверяем, сохранял ли ранее преподаватель такой шаблон. Если да, то обновляем его, иначе добавляем его ему.
            var userTemplate = await _templateRepository.GetUserTemplateByTemplateIdAsync(templateId, user.UserId);

            // Если у преподавателя еще не было сохранено такого шаблона, то добавляем.
            if (userTemplate is null)
            {
                await _templateRepository.AddTemplateAsync(templateId, user.UserId, template);
                return;
            }
            
            // Изменяем шаблон преподавателя, раз у преподавателя он уже добавлен ранее.
            await _templateRepository.ChangeTemplateAsync(userTemplate);
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}