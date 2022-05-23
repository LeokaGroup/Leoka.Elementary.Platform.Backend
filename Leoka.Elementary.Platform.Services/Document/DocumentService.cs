using Leoka.Elementary.Platform.Abstractions.Document;
using Leoka.Elementary.Platform.Abstractions.Profile;
using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Leoka.Elementary.Platform.Services.Document;

/// <summary>
/// Класс реализует методы сервиса документов.
/// </summary>
public class DocumentService : IDocumentService
{
    private readonly IUserRepository _userRepository;
    private readonly IProfileService _profileService;
    
    public DocumentService(IUserRepository userRepository,
        IProfileService profileService)
    {
        _userRepository = userRepository;
        _profileService = profileService;
    }

    /// <summary>
    /// Метод получит список сертификатов для профиля пользователя.
    /// </summary>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Список сертификатов.</returns>
    public async Task<IEnumerable<FileContentResult>> GetProfileCertsAsync(string account)
    {
        try
        {
            var user = await _userRepository.GetUserByEmailAsync(account);

            if (user is null)
            {
                throw new NotFoundUserException(account);
            }

            // Получит список сертификатов пользователя.
            var certs = await _profileService.GetUserCertsAsync(user.UserId);
            
            // Получит список файлов сертификатов с сервера.
            // var result = 

            return null;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}