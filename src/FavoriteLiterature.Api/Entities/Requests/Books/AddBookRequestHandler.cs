using FavoriteLiterature.Api.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Entities.Requests.Books;

public class AddBookRequestHandler : IRequestHandler<AddBookRequest>
{
    private readonly IRepository _repository;

    public AddBookRequestHandler(IRepository? repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<Unit> Handle(AddBookRequest request, CancellationToken cancellationToken)
    {
        var user = await _repository.Users
            .FirstOrDefaultAsync(user => user.Id == request.UserId, cancellationToken);
        
        if (user == null)
        { 
            throw new ArgumentException(nameof(user));
        }
        
        var author = await _repository.Authors.FirstOrDefaultAsync(author => 
            author.UserId == user.Id, 
            cancellationToken);
        
        if (author == null)
        { 
            throw new ArgumentException(nameof(author));
        }
        
        Book book = new Book(request.Name, author.Id, request.Description);
        
        await _repository.Create(book, cancellationToken);

         return Unit.Value;
    }
}