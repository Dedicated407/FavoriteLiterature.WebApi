using FavoriteLiterature.Api.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Entities.Requests.Authors;

public class AddAuthorRequestHandler : IRequestHandler<AddAuthorRequest>
{
    private readonly IRepository _repository;

    public AddAuthorRequestHandler(IRepository? repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public async Task<Unit> Handle(AddAuthorRequest request, CancellationToken cancellationToken)
    {
        User user = await _repository.Users
            .FirstOrDefaultAsync(user => user.Id == request.UserId, cancellationToken) 
                    ?? throw new ArgumentException(nameof(user));

        Author author = new Author(user.Id, request.Description, 
            request.Birthday, request.PhoneNumber, request.Address, request.Rating);

        await _repository.Create(author, cancellationToken);
        
        return Unit.Value;
    }
}