using FavoriteLiterature.Client.Models.Books;
using MediatR;

namespace FavoriteLiterature.Api.Entities.Requests.Books;

public class GetBooksListRequest : GetBooksListRequestModel, IRequest<List<Book>>
{
}