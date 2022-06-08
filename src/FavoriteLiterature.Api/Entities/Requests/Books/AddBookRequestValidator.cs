using FluentValidation;

namespace FavoriteLiterature.Api.Entities.Requests.Books;

public class AddBookRequestValidator : AbstractValidator<AddBookRequest>
{
    private const byte MinimumRating = 0;
    private const byte MaximumRating = 10;
    
    public AddBookRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Rating)
            .Must(x => x is >= MinimumRating and <= MaximumRating)
            .WithMessage("Рейтинг варируется от 0 до 10");
    }
}