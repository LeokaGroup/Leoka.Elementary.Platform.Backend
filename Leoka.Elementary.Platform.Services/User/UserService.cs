using IdentityModel.Client;
using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Base.Abstraction;
using Leoka.Elementary.Platform.Core.Exceptions;
using Leoka.Elementary.Platform.Core.Utils;
using Leoka.Elementary.Platform.Mailings.Abstractions;
using Leoka.Elementary.Platform.Models.User.Output;

namespace Leoka.Elementary.Platform.Services.User;

/// <summary>
/// Класс реализует методы сервиса пользователя.
/// </summary>
public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMailingsService _mailingsService;

    public UserService(IUserRepository userRepository,
        IMailingsService mailingsService)
    {
        _userRepository = userRepository;
        _mailingsService = mailingsService;
    }

    /// <summary>
    /// Метод создаст нового пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="userEmail">Email пользователя.</param>
    /// <param name="roleSysName">Системное название роли.</param>
    /// <param name="userPhoneNumber">Номер телефона.</param>
    /// <returns>Данные пользователя.</returns>
    public async Task<UserOutput> CreateUserAsync(string name, string userEmail, string userRole, string userPhoneNumber)
    {
        try
        {
            if (string.IsNullOrEmpty(name) 
                || string.IsNullOrEmpty(userEmail)
                || string.IsNullOrEmpty(userRole)
                || string.IsNullOrEmpty(userPhoneNumber))
            {
                throw new EmptyRequiredFieldsException();
            }
            
            // Создаст пользователя.
            var result = await _userRepository.CreateUserAsync(name, userEmail, userRole, userPhoneNumber);
            
            // Создаст дефолтный пароль пользователю для отправки на почту.
            var password = await GenerateUserPasswordAsync();
            
            // Хэширует пароль.
            var commonService = AutoFac.Resolve<ICommonService>();
            var hashPassword = await commonService.HashPasswordAsync(password);
            
            // Обновит пароль пользователю.
            await _userRepository.UpdateUserPasswordAsync(result.UserId.ToString(), hashPassword);
            
            // Отправит пароль пользователю на email и заодно для подтверждения почты. 
            await _mailingsService.SendConfirmEmailAsync(result.Email, result.UserName, password, result.ConfirmEmailCode);

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
    /// Метод авторизует пользователя.
    /// </summary>
    /// <param name="userLogin">Email или номер телефона.</param>
    /// <param name="userPassword">Пароль.</param>
    public async Task<string> SignInAsync(string userLogin, string userPassword)
    {
        try
        {
            userPassword = userPassword.Replace("/.well-known/openid-configuration", "");
            var IsAuth = await _userRepository.SignInAsync(userLogin, userPassword);
            
            if (!IsAuth)
            {
                throw new ErrorUserAuthorizeException(userLogin);
            }
            
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:9991");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });
            
            return tokenResponse.AccessToken;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<string> GenerateUserPasswordAsync()
    {
        var result = string.Empty;
        var arr = new[]
        {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P",
            "Q", "R", "S", "T", "V", "W", "X", "Z", "b", "c", "d", "f", "g", "h", "j", "k", "m", "n", "p", "q", "r",
            "s", "t", "v", "w", "x", "z", "A", "E", "U", "Y", "a", "e", "i", "o", "u", "y"
        };
        
        var rnd = new Random();
        
        for (var i = 0; i < 8; i += 1)
        {
            result += arr[rnd.Next(0, 57)];
        }

        return await Task.FromResult(result);
    }
    
    /// <summary>
    /// Метод отправит пользователя на страницу успешного подтверждения почты.
    /// </summary>
    /// <param name="code">Код подтверждения (guid).</param>
    /// <returns>Редиректит на страницу успеха.</returns>
    public async Task<bool> ConfirmEmailAccountCode(string code)
    {
        try
        {
            if (string.IsNullOrEmpty(code))
            {
                return false;
            }

            var isConfirm = await _userRepository.ConfirmEmailAccountCode(code);

            return isConfirm;
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}