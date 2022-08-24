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
        Author author = await _repository.Authors
                            .FirstOrDefaultAsync(author => author.Id == request.AuthorId, cancellationToken)
                        ?? throw new ArgumentException(nameof(author));

        User user = await _repository.Users
                        .FirstOrDefaultAsync(user => user.Id == author.UserId, cancellationToken)
                    ?? throw new ArgumentException(nameof(user));

        Book book = new Book(request.Name, author.Id, request.Rating, request.Description);

        await _repository.Create(book, cancellationToken);

        return Unit.Value;
    }
}