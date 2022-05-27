using FavoriteLiterature.Client.Models.Books;
using MediatR;

namespace FavoriteLiterature.Api.Entities.Requests.Books;

public class AddBookRequest : AddBookRequestModel, IRequest
{
}