using FavoriteLiterature.Api.Infrastructure.Interfaces;
using FavoriteLiterature.Client.Models.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Entities.Requests.Users.Profile;

public class GetUserProfileHandler : IRequestHandler<GetUserProfileRequest, UserProfileModel>
{
    private readonly IRepository _repository;

    public GetUserProfileHandler(IRepository? repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<UserProfileModel> Handle(GetUserProfileRequest request, CancellationToken cancellationToken)
    {
        var user = await _repository.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        var role = _repository.Roles.First(x => x.Id == user!.RoleId);
        
        return new UserProfileModel
        {
            UserName = user!.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Patronymic = user.Patronymic,
            Role = role.Name
        };
    }
}