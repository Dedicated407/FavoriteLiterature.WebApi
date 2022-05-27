using FavoriteLiterature.Api.Entities.Enums;
using Microsoft.AspNetCore.Authorization;

namespace FavoriteLiterature.Api.Policies;

public class MinimumRoleRequirement : IAuthorizationRequirement
{
    public MinimumRoleRequirement(Roles role)
    {
        Role = role;
    }

    public Roles Role { get; private set; }
}
// Для понимания - https://habr.com/ru/post/322566/