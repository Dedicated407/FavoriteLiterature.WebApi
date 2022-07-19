using FavoriteLiterature.Client.Models;
using MediatR;

namespace FavoriteLiterature.Api.Entities.Requests.Books;

public class GetBooksListRequest : GetListRequestModel, IRequest<List<Book>>
{
}