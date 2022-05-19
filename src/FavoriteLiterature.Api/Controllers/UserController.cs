using FavoriteLiterature.Api.Entities.Requests.Users.JwtToken;
using FavoriteLiterature.Api.Entities.Requests.Users.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    /// <summary>
    /// Регистрация пользователя в системе
    /// </summary>
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request) => 
        Ok(await _mediator.Send(request));
    
    /// <summary>
    /// Получение JWT токена
    /// </summary>
    [AllowAnonymous]
    [HttpPost("token")]
    public async Task<IActionResult> GetJwtToken([FromBody] GetJwtTokenRequest request) => 
        Ok(await _mediator.Send(request));
}