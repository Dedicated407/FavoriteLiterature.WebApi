using FavoriteLiterature.Api.Entities.Requests.Users.JwtToken;
using FavoriteLiterature.Api.Entities.Requests.Users.Register;
using FavoriteLiterature.Client.Models.Users;
using FavoriteLiterature.Client.Models.Users.JwtToken;
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
    /// <param name="request">
    /// Необходимые поля для регистрации указаны в <see cref="RegisterRequestModel"/>.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается ошибка, когда пользователь с таким <see cref="RegisterRequestModel.Email"/> уже существует.
    /// </exception>
    /// </summary>
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request) => 
        Ok(await _mediator.Send(request));
    
    /// <summary>
    /// Получение JWT токена.
    /// <param name="request">
    /// Необходимо ввести <see cref="JwtTokenRequestModel.Email"/>
    /// и <see cref="JwtTokenRequestModel.Password"/>.
    /// </param>
    /// </summary>
    [AllowAnonymous]
    [HttpPost("token")]
    public async Task<IActionResult> GetJwtToken([FromBody] GetJwtTokenRequest request) => 
        Ok(await _mediator.Send(request));
}