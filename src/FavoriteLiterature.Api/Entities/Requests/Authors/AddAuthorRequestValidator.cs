using System.Text.RegularExpressions;
using FluentValidation;

namespace FavoriteLiterature.Api.Entities.Requests.Authors;

public class AddAuthorRequestValidator : AbstractValidator<AddAuthorRequest>
{
    private const byte MinimumRating = 0;
    private const byte MaximumRating = 10;
    
    public AddAuthorRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.PhoneNumber)
            .Must(number => 
                number == null || 
                Regex.IsMatch(number, "^[\\+]?[0-9]{1,3}[(]?[0-9]{3}[)]?[0-9]{3}[-\\s\\.]?[0-9]{2}[-\\s\\.]?[0-9]{2}$"))
            .WithMessage("Введен некорректный номер телефона, попробуйте номер следующего формата: " +
                         "89999999999, +79999999999, +7(999)9999999, +7(999)999-99-99");
        
        RuleFor(x => x.Rating)
            .Must(x => x is >= MinimumRating and <= MaximumRating)
            .WithMessage("Рейтинг варируется от 0 до 10");
    }
}