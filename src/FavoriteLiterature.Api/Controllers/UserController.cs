using FavoriteLiterature.Api.Entities;
using FavoriteLiterature.Api.Entities.Requests.Users.Register;
using FavoriteLiterature.Api.Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRepository<User> _repository;

    public UserController(IMediator mediator, IRepository<User> repository)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _repository = repository;
    }
    
    /// <summary>
    /// Регистрация пользователя в системе
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request) => 
        Ok(await _mediator.Send(request));
}