﻿using FavoriteLiterature.Api.Infrastructure.Interfaces;
using FavoriteLiterature.Client.Models.Authors;
using FavoriteLiterature.Client.Models.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Entities.Requests.Books;

public class GetBookHandler : IRequestHandler<GetBookRequest, BookModel>
{ 
    private readonly IRepository _repository;

    public GetBookHandler(IRepository? repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public async Task<BookModel> Handle(GetBookRequest request, CancellationToken cancellationToken)
    {
        var book = await _repository.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (book == null)
        {
            throw new ApplicationException($"Book with Id={request.Id} is not found!");
        }
        
        var author = await _repository.Authors.FirstOrDefaultAsync(x => x.Id == book.AuthorId, cancellationToken);
        var authorInfo = await _repository.Users.FirstOrDefaultAsync(x => x.Id == author.UserId, cancellationToken: cancellationToken);
        author.User = authorInfo;
        book.Author = author;

        var responseModel = new BookModel
        {
            Id = book.Id,
            Name = book.Name,
            Author = new AuthorModel
            {
                Id = author.UserId,
                UserName = author.User.UserName,
                Email = author.User.Email,
                FirstName = author.User.FirstName!,
                LastName = author.User.LastName!,
                Patronymic = author.User.Patronymic!,
            },
            Rating = book.Rating,
            Description = book.Description
        };

        return responseModel;
    }
}