using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Base.Abstraction;
using Leoka.Elementary.Platform.Core.Utils;
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
    /// <param name="contactData">Контактные данные пользователя (email или телефон).</param>
    /// <param name="roleSysName">Системное название роли.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Данные пользователя.</returns>
    public async Task<UserOutput> CreateUserAsync(string name, string contactData, string userRole, string password)
    {
        try
        {
            // Хэширует пароль.
            var commonService = AutoFac.Resolve<ICommonService>();
            var hashPassword = await commonService.HashPasswordAsync(password);
            var result = await _userRepository.CreateUserAsync(name, contactData, userRole, hashPassword);

            return result;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ClaimOutput> SignInAsync(string userLogin, string userPassword)
    {
        try
        {
            var result = await _userRepository.SignInAsync(userLogin, userPassword);

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