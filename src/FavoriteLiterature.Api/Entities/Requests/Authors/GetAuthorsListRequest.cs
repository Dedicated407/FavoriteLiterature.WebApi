using FavoriteLiterature.Client.Models;
using FavoriteLiterature.Client.Models.Authors;
using MediatR;

namespace FavoriteLiterature.Api.Entities.Requests.Authors;

public class GetAuthorsListRequest : GetListRequestModel, IRequest<ICollection<AuthorModel>>
{
}