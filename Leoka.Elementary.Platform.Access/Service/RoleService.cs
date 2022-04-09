using Leoka.Elementary.Platform.Access.Abstraction;
using Leoka.Elementary.Platform.Models.Role.Output;

namespace Leoka.Elementary.Platform.Access.Service;

/// <summary>
/// Класс реализует методы сервиса ролей.
/// </summary>
public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    
    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    /// <summary>
    /// Метод получит список ролей.
    /// </summary>
    /// <returns>Список ролей.</returns>
    public async Task<IEnumerable<RoleOutput>> GetRolesAsync()
    {
        try
        {
            var result = await _roleRepository.GetRolesAsync();

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