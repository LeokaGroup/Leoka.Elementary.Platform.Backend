using Leoka.Elementary.Platform.Models.User.Output;

namespace Leoka.Elementary.Platform.Abstractions.User;

/// <summary>
/// Абстракция сервиса пользователей.
/// </summary>
public interface IUserService
{
    Task<UserOutput> CreateUserAsync(string name, string email, string phoneNumber, string userRole, string password);
}