using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Leoka.Elementary.Platform.Access.Abstraction;
using Leoka.Elementary.Platform.Backend.Core.Data;
using Leoka.Elementary.Platform.Models.Role.Output;
using Leoka.Elementary.Platform.Models.User.Output;
using Microsoft.IdentityModel.Tokens;

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
    
    /// <summary>
    /// Метод обновит токен.
    /// </summary>
    /// <returns>Новый токен.</returns>
    public async Task<ClaimOutput> GenerateTokenAsync()
    {
        try
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: new ClaimsIdentity().Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var result = new ClaimOutput
            {
                Token = encodedJwt
            };

            return await Task.FromResult(result);
        }

        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}