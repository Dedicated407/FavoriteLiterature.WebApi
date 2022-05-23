using System.Security.Claims;
using FavoriteLiterature.Api.Entities.Enums;
using Microsoft.AspNetCore.Authorization;

namespace FavoriteLiterature.Api.Policies;

public class MinimumRoleRequirementHandler : AuthorizationHandler<MinimumRoleRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumRoleRequirement requirement)
    {
        var roleName = context.User.FindFirst(claim => claim.Type == ClaimTypes.Role)?.Value;
        
        if (roleName == null)
        {
            return Task.CompletedTask;
        }
        
        if (!Enum.TryParse(typeof(Roles), roleName, true, out var parsedRole))
        {
            return Task.CompletedTask;
        }

        if (parsedRole != null && (Roles) parsedRole >= requirement.Role)
        {
            context.Succeed(requirement);
        }
        
        return Task.CompletedTask;
    }
}