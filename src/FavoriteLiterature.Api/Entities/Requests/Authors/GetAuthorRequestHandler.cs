using FavoriteLiterature.Api.Infrastructure.Interfaces;
using FavoriteLiterature.Client.Models.Authors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Entities.Requests.Authors;

public class GetAuthorRequestHandler : IRequestHandler<GetAuthorRequest, AuthorProfileModel>
{
    private readonly IRepository _repository;

    public GetAuthorRequestHandler(IRepository? repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }


    public async Task<AuthorProfileModel> Handle(GetAuthorRequest request, CancellationToken cancellationToken)
    {
        var author = await _repository.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        
        if (author == null)
        {
            throw new ApplicationException($"Author with Id={request.Id} is not found!");  
        }

        var authorInfo = await _repository.Authors.FirstOrDefaultAsync(x => x.UserId == author.Id, cancellationToken);
        
        return new AuthorProfileModel
        {
            Id = author.Id,
            UserName = author.UserName,
            Email = author.Email,
            FirstName = author.FirstName!,
            LastName = author.LastName!,
            Patronymic = author.Patronymic!,
            Description = authorInfo!.Description,
            Birthday = authorInfo.Birthday,
            PhoneNumber = authorInfo.PhoneNumber,
            Address = authorInfo.Address,
            Rating = authorInfo.Rating,
        };
    }
}