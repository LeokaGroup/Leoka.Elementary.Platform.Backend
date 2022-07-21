using IdentityServer4.Models;
using Leoka.Elementary.Platform.Access.Consts;

namespace Leoka.Elementary.Platform.Access.IdentityServer;

/// <summary>
/// Класс конфигураций, который решает, какие приложения будут иметь доступ к нашему IdentityServer.
/// </summary>
public static class Configuration
{
    /// <summary>
    /// Список ресурсов, которые хотим защитить.
    /// </summary>
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new("api1", IdentityServerConsts.ApiName)
        };

    /// <summary>
    /// Список ресурсов, которые имеют доступ к ресурсам ApiScopes. 
    /// </summary>
    // public static IEnumerable<IdentityResource> IdentityResources =>
    //     new List<IdentityResource>
    //     {
    //         new IdentityResources.OpenId(),
    //         new IdentityResources.Profile()
    //     };
    //
    // /// <summary>
    // /// Список API-ресурсов.
    // /// </summary>
    // public static IEnumerable<ApiResource> ApiResources =>
    //     new List<ApiResource>
    //     {
    //         new(IdentityServerConsts.ApiName, new[] { JwtClaimTypes.Email })
    //         {
    //             Scopes = { IdentityServerConsts.ApiName }
    //         }
    //     };
    
    // Спислк клиентов приложения (список приложений, которые могут использовать платформу).
    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                //leoka-elementary-api
                ClientId = "client",
                // ClientName = IdentityServerConsts.ApiName,
                // AllowedGrantTypes = GrantTypes.Code,
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                // RequireClientSecret = false,
                // RequirePkce = true,
                // RedirectUris =
                // {
                //     // TODO: получать из конфига приложения!
                //     "https://leoka-elementary.site",
                //     "http://localhost:4200"
                // },
                // AllowedCorsOrigins =
                // {
                //     // TODO: получать из конфига приложения!
                //     "https://leoka-elementary.site",
                //     "http://localhost:4200"
                // },
                // PostLogoutRedirectUris =
                // {
                //     // TODO: получать из конфига приложения!
                //     "https://leoka-elementary.site",
                //     "http://localhost:4200"
                // },
                AllowedScopes =
                {
                    "api1"
                    // IdentityServerConstants.StandardScopes.OpenId,
                    // IdentityServerConstants.StandardScopes.Profile,
                    // IdentityServerConsts.ApiName
                }
                // AllowAccessTokensViaBrowser = true  // Для передачи токена доступа через браузер.
            }
        };
}