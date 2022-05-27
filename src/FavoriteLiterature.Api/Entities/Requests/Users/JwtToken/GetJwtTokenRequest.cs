using FavoriteLiterature.Client.Models.Users.JwtToken;
using MediatR;

namespace FavoriteLiterature.Api.Entities.Requests.Users.JwtToken;

public class GetJwtTokenRequest : JwtTokenRequestModel, IRequest<JwtTokenResponseModel>
{
}