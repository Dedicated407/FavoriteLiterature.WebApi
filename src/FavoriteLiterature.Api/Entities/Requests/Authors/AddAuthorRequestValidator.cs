using System.Text.RegularExpressions;
using FluentValidation;

namespace FavoriteLiterature.Api.Entities.Requests.Authors;

public class AddAuthorRequestValidator : AbstractValidator<AddAuthorRequest>
{
    public AddAuthorRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.PhoneNumber)
            .Must(number => 
                number == null || 
                Regex.IsMatch(number, "^[\\+]?[0-9]{1,3}[(]?[0-9]{3}[)]?[0-9]{3}[-\\s\\.]?[0-9]{2}[-\\s\\.]?[0-9]{2}$"))
            .WithMessage("Введен некорректный номер телефона, попробуйте номер следующего формата: " +
                         "\n89999999999\n+79999999999\n+7(999)9999999\n+7(999)999-99-99");
    }
}