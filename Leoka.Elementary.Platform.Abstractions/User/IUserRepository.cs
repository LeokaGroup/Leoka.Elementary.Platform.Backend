using Leoka.Elementary.Platform.Models.User.Output;

namespace Leoka.Elementary.Platform.Abstractions.User;

/// <summary>
/// Абстракция репозитория пользователя для работы с БД.
/// </summary>
public interface IUserRepository
{
    Task<UserOutput> CreateUserAsync(string name, string email, string phoneNumber, string userRole, string password);
}