using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Leoka.Elementary.Platform.Access.Consts;

namespace Leoka.Elementary.Platform.Access.IdentityServer;

/// <summary>
/// Класс конфигураций, который решает, какие приложения будут иметь доступ к нашему IdentityServer.
/// </summary>
public static class Configuration
{
    /// <summary>
    /// Список областей.
    /// </summary>
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new(IdentityServerConsts.ApiName)
        };

    /// <summary>
    /// Список identity-ресурсов.
    /// </summary>
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    /// <summary>
    /// Список API-ресурсов.
    /// </summary>
    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new(IdentityServerConsts.ApiName, new[] { JwtClaimTypes.Name })
            {
                Scopes = { IdentityServerConsts.ApiName }
            }
        };
    
    // Спислк клиентов приложения (список приложений, которые могут использовать платформу).
    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                ClientId = "leoka-elementary-web-api",
                ClientName = IdentityServerConsts.ApiName,
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris =
                {
                    // TODO: получать из конфига приложения!
                    "https://leoka-elementary.site"
                },
                AllowedCorsOrigins =
                {
                    // TODO: получать из конфига приложения!
                    "https://leoka-elementary.site"
                },
                PostLogoutRedirectUris =
                {
                    // TODO: получать из конфига приложения!
                    "https://leoka-elementary.site"
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConsts.ApiName
                },
                AllowAccessTokensViaBrowser = true  // Для передачи токена доступа через браузер.
            }
        };
}