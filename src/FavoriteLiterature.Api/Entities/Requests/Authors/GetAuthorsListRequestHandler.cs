using FavoriteLiterature.Api.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Entities.Requests.Authors;

public class GetAuthorsListRequestHandler : IRequestHandler<GetAuthorsListRequest, List<Author>>
{
    private readonly IRepository _repository;

    public GetAuthorsListRequestHandler(IRepository? repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public async Task<List<Author>> Handle(GetAuthorsListRequest request, CancellationToken cancellationToken)
    {
        var authors = _repository.Authors;

        var result = await authors.OrderBy(x => x.User.LastName).ToListAsync(cancellationToken);

        return result;
    }
}