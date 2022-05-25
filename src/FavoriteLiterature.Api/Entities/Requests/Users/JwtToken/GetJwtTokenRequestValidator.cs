using FluentValidation;

namespace FavoriteLiterature.Api.Entities.Requests.Users.JwtToken;

public class GetJwtTokenRequestValidator : AbstractValidator<GetJwtTokenRequest>
{
    public GetJwtTokenRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}