﻿using FavoriteLiterature.Api.Entities;
using FavoriteLiterature.Api.Entities.Enums;
using FavoriteLiterature.Api.Entities.Requests.Authors;
using FavoriteLiterature.Client.Models.Authors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Api.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Добавление автора в репозиторий.
    /// </summary>
    [HttpPost]
    [Authorize(Policy = nameof(Roles.Critic))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddAuthorRequest request) =>
        Ok(await _mediator.Send(request));
    
    /// <summary>
    /// Получение списка авторов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList([FromQuery] GetAuthorsListRequest request) =>
        Ok(await _mediator.Send(request));
    
    /// <summary>
    /// Получение профиля автора по Id
    /// </summary>
    [HttpGet("author")]
    [ProducesResponseType(typeof(AuthorProfileModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthorProfile([FromQuery] Guid id) =>
        Ok(await _mediator.Send(new GetAuthorRequest(id)));
    
}