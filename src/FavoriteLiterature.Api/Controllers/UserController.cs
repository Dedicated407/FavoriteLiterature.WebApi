using System.Security.Claims;
using FavoriteLiterature.Api.Entities.Requests.Users.JwtToken;
using FavoriteLiterature.Api.Entities.Requests.Users.Profile;
using FavoriteLiterature.Api.Entities.Requests.Users.Register;
using FavoriteLiterature.Client.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Api.Controllers;

/// <summary>
/// Класс <see cref="UserController"/>.
/// Контроллер, предназначенный для работы с пользователем. 
/// </summary>
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
    /// Регистрация пользователя в системе.
    /// </summary>
    [AllowAnonymous]
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request) => 
        Ok(await _mediator.Send(request));
    
    /// <summary>
    /// Получение JWT токена.
    /// </summary>
    [AllowAnonymous]
    [HttpPost("token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetJwtToken([FromBody] GetJwtTokenRequest request) => 
        Ok(await _mediator.Send(request));
    
    /// <summary>
    /// Получение информации о пользователе по токену
    /// </summary>
    [HttpGet("current")]
    [ProducesResponseType(typeof(UserProfileModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProfile()
    {
        var userId = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
        return Ok(await _mediator.Send(new GetUserProfileRequest(Guid.Parse(userId))));
    }
}