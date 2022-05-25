using FluentValidation;

namespace FavoriteLiterature.Api.Entities.Requests.Books;

public class AddBookRequestValidator : AbstractValidator<AddBookRequest>
{
    public AddBookRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}