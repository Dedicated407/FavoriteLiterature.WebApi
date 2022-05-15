using FavoriteLiterature.Api.Entities.Enums;
using FavoriteLiterature.Api.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Api.Entities.Requests.Users.Register;

public class RegisterRequestHandler : IRequestHandler<RegisterRequest>
{
    private readonly IRepository<User> _repository;

    public RegisterRequestHandler(IRepository<User> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public async Task<Unit> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        if (await _repository.GetAll().AnyAsync(user => user.Email == request.Email, cancellationToken))
        {
            throw new ArgumentException($"This email {request.Email} already exist, use another one.");
        }   

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        User user = new User(request.UserName, request.Email, passwordHash, (int) Roles.User);
        
        await _repository.Create(user, cancellationToken);
        
        return Unit.Value;
    }
}