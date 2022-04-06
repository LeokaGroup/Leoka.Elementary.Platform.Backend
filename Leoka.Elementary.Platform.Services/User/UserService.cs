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

    /// <summary>
    /// Метод создаст нового пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="email">Email.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="roleSysName">Системное название роли.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Данные пользователя.</returns>
    public async Task<UserOutput> CreateUserAsync(string name, string email, string phoneNumber, string userRole, string password)
    {
        try
        {
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