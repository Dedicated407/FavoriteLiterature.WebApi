using System.Text.RegularExpressions;
using FluentValidation;

namespace FavoriteLiterature.Api.Entities.Requests.Users.Register;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    private const int MinimumPasswordLength = 5;
    private const int MinimumUserNameLength = 2;
	
    public RegisterRequestValidator()
    {
        RuleFor(x => x.UserName)
            .MinimumLength(MinimumUserNameLength)
            .WithMessage("Минимальная длина никнейма - 2");
        
        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
		
        RuleFor(x => x.Password)
            .MinimumLength(MinimumPasswordLength)
            .WithMessage("Минимальная длина пароля - 5");
		
        RuleFor(x => x.Password)
            .Must(s => Regex.IsMatch(s, "[a-z]", RegexOptions.IgnoreCase))
            .WithMessage("'Password' должен содержать хотя бы одну букву!");
		
        RuleFor(x => x.Password)
            .Must(s => Regex.IsMatch(s, "[0-9]", RegexOptions.IgnoreCase))
            .WithMessage("'Password' должен содержать хотя бы одну цифру!");
		
        RuleFor(x => x.PasswordConfirmation)
            .Equal(x => x.Password)
            .WithMessage("'PasswordConfirmation' не совпадает с 'Password'");
    }
}