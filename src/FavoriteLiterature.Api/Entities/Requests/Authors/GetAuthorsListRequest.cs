using FavoriteLiterature.Client.Models.Authors;
using MediatR;

namespace FavoriteLiterature.Api.Entities.Requests.Authors;

public class GetAuthorsListRequest : GetAuthorsListRequestModel, IRequest<List<Author>>
{
}