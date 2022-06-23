using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Leoka.Elementary.Platform.Core.Filters;

public class AuthFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.User.Identity is not null 
            && !context.HttpContext.User.Identity.IsAuthenticated
            && !new[] {"GetProfileMenuItems"}.Contains(context.RouteData.Values["action"]))
        {
            context.Result =  new ForbidResult();
        }
    }
}