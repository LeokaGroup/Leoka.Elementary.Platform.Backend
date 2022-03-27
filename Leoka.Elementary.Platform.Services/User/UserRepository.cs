using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Models.Entities.User;
using Leoka.Elementary.Platform.Models.User.Output;
using Microsoft.AspNetCore.Identity;

namespace Leoka.Elementary.Platform.Services.User;

/// <summary>
/// Класс реализует методы репозитория пользователя при работе с БД.
/// </summary>
public sealed class UserRepository : IUserRepository
{
    private readonly PostgreDbContext _postgreDbContext;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    
    public UserRepository(PostgreDbContext postgreDbContext,
        UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager)
    {
        _postgreDbContext = postgreDbContext;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<UserOutput> CreateUserAsync(string name, string email, string phoneNumber, string userRole, string password)
    {
        try
        {
            // var result = await _userManager.CreateAsync(new UserEntity
            // {
            //     Email = email,
            //     UserName = email
            // }, password);
            //
            // if (result.Succeeded)
            // {
            //     
            // }

            return new UserOutput();
        }
        
        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}