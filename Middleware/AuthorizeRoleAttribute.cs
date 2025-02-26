using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace WebApplication2.Middleware;

public class AuthorizeRoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly int _roleId;

    public AuthorizeRoleAttribute(int roleId)
    {
        _roleId = roleId;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        if (user.Identity != null && !user.Identity.IsAuthenticated)
        {
            context.Result = new ForbidResult();
            return;
        }
        
        var roleIdClaim = user.FindFirst("VaiTroId");
        if (roleIdClaim == null || !int.TryParse(roleIdClaim.Value, out int roleId) || roleId != _roleId)
        {
            context.Result = new ForbidResult();
        }
    }
}