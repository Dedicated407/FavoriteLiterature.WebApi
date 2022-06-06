using FavoriteLiterature.Client.Models.Authors;
using MediatR;

namespace FavoriteLiterature.Api.Entities.Requests.Authors;

public record GetAuthorRequest(Guid Id) : IRequest<AuthorProfileModel>;