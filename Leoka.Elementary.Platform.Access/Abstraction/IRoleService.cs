using Leoka.Elementary.Platform.Models.Role.Output;

namespace Leoka.Elementary.Platform.Access.Abstraction;

/// <summary>
/// Абстракция сервиса для работы с ролями.
/// </summary>
public interface IRoleService
{
    /// <summary>
    /// Метод получит список ролей.
    /// </summary>
    /// <returns>Список ролей.</returns>
    Task<IEnumerable<RoleOutput>> GetRolesAsync();
    
    /// <summary>
    /// Метод обновит токен.
    /// </summary>
    /// <returns>Новый токен.</returns>
    // Task<ClaimOutput> GenerateTokenAsync(string account);
}