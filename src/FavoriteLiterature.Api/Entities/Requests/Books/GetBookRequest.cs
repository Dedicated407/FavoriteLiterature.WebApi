using FavoriteLiterature.Client.Models.Books;
using MediatR;

namespace FavoriteLiterature.Api.Entities.Requests.Books;

public record GetBookRequest(Guid Id) : IRequest<BookModel>;