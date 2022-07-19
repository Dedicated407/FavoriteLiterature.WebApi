using FavoriteLiterature.Api.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Entities.Requests.Books;

public class GetBooksListRequestHandler : IRequestHandler<GetBooksListRequest, List<Book>>
{
    private readonly IRepository _repository;

    public GetBooksListRequestHandler(IRepository? repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public async Task<List<Book>> Handle(GetBooksListRequest request, CancellationToken cancellationToken)
    {
        var pattern = $"%{request.Query}%";
        
        var result = await _repository.Books
            .OrderBy(x => x.Name)
            .Where(x => EF.Functions.ILike(x.Name, pattern))
            .Skip(request.Skip)
            .Take(request.Take)
            .ToListAsync(cancellationToken);
        
        return result;
    }
}