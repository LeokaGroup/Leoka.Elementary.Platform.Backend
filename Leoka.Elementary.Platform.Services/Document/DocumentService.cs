using Leoka.Elementary.Platform.Abstractions.Document;
using Leoka.Elementary.Platform.Abstractions.Profile;
using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Core.Exceptions;
using Leoka.Elementary.Platform.FTP.Abstractions;
using Leoka.Elementary.Platform.Models.Profile.Output;

namespace Leoka.Elementary.Platform.Services.Document;

/// <summary>
/// Класс реализует методы сервиса документов.
/// </summary>
public class DocumentService : IDocumentService
{
    private readonly IUserRepository _userRepository;
    private readonly IProfileService _profileService;
    private readonly IFtpService _ftpService;
    
    public DocumentService(IUserRepository userRepository,
        IProfileService profileService,
        IFtpService ftpService)
    {
        _userRepository = userRepository;
        _profileService = profileService;
        _ftpService = ftpService;
    }

    /// <summary>
    /// Метод получит список сертификатов для профиля пользователя.
    /// </summary>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Список сертификатов.</returns>
    public async Task<IEnumerable<FileContentResultOutput>> GetProfileCertsAsync(string account)
    {
        try
        {
            var user = await _userRepository.GetUserByEmailAsync(account);
            IEnumerable<FileContentResultOutput> result = null;

            if (user is null)
            {
                throw new NotFoundUserException(account);
            }

            // Получит список сертификатов пользователя.
            var certsNames = await _profileService.GetUserCertsAsync(user.UserId);

            if (certsNames.Any())
            {
                // Получит список файлов сертификатов с сервера.
                result = await _ftpService.GetUserCertsFilesAsync(user.UserId, certsNames);
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
}