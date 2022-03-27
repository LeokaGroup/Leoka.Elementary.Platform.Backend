using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Models.User.Output;

namespace Leoka.Elementary.Platform.Services.User;

/// <summary>
/// Класс реализует методы сервиса пользователя.
/// </summary>
public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserOutput> CreateUserAsync(string name, string email, string phoneNumber, string userRole, string password)
    {
        try
        {
            // TODO: добавить проверки входных + оменять в БД роль на id роли. 
            var result = await _userRepository.CreateUserAsync(name, email, phoneNumber, userRole, password);

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