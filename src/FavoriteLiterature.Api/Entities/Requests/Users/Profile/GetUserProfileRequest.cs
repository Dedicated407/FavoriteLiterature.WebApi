using FavoriteLiterature.Client.Models.Users;
using MediatR;

namespace FavoriteLiterature.Api.Entities.Requests.Users.Profile;

public record GetUserProfileRequest(Guid Id) : IRequest<UserProfileModel>;