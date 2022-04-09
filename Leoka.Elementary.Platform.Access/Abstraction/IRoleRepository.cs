using Leoka.Elementary.Platform.Models.Role.Output;

namespace Leoka.Elementary.Platform.Access.Abstraction;

/// <summary>
/// Абстракция репозитория для работы с ролями.
/// </summary>
public interface IRoleRepository
{
    /// <summary>
    /// Метод получит список ролей.
    /// </summary>
    /// <returns>Список ролей.</returns>
    Task<IEnumerable<RoleOutput>> GetRolesAsync();
}