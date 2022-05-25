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
        var books = _repository.Books;
        var pattern = $"%{request.Query}%";
        
        var result = await books
            .Where(x => EF.Functions.ILike(x.Name, pattern))
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
        
        return result;
    }
}