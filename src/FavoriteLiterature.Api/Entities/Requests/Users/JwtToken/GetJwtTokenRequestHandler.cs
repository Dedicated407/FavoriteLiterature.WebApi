using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FavoriteLiterature.Api.Entities.Enums;
using FavoriteLiterature.Api.Infrastructure.Interfaces;
using FavoriteLiterature.Api.Options;
using FavoriteLiterature.Client.Models.Users.JwtToken;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FavoriteLiterature.Api.Entities.Requests.Users.JwtToken;

public class GetJwtTokenRequestHandler : IRequestHandler<GetJwtTokenRequest, JwtTokenResponseModel>
{
    private readonly IRepository _repository;
    private readonly JwtOptions _jwtOptions;
    
    public GetJwtTokenRequestHandler(IRepository repository, IOptions<JwtOptions> jwtOptions)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _jwtOptions = jwtOptions.Value;
    }
    
    public async Task<JwtTokenResponseModel> Handle(GetJwtTokenRequest request, CancellationToken cancellationToken)
    { 
        var user = await _repository.Users.FirstOrDefaultAsync(user => 
            user.Email == request.Email,
            cancellationToken);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            throw new ArgumentException(nameof(user));
        }

        var claims = new List<Claim>
        {
            new (ClaimTypes.Email, user.Email),
            new (ClaimTypes.Name, user.UserName),
            new (ClaimTypes.Role, ((Roles) user.RoleId).ToString()),
        };

        var jwtToken = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: null,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(_jwtOptions.Lifetime),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256)
        );
        
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);
 
        var response = new JwtTokenResponseModel
        {
            TypeToken = JwtBearerDefaults.AuthenticationScheme,
            AccessToken = encodedJwt,
            Lifetime = _jwtOptions.Lifetime,
            Email = user.Email
        };
 
        return response;
    }
}