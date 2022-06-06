using FavoriteLiterature.Api.Entities;
using FavoriteLiterature.Api.Entities.Enums;
using FavoriteLiterature.Api.Entities.Requests.Books;
using FavoriteLiterature.Client.Models.Books;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Api.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Добавление книги в репозиторий.
    /// </summary>
    [HttpPost]
    [Authorize(Policy = nameof(Roles.Author))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Add([FromBody] AddBookRequest request) =>
        Ok(await _mediator.Send(request));
    
    /// <summary>
    /// Получение списка книг
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList([FromQuery] GetBooksListRequest request) =>
        Ok(await _mediator.Send(request));
    
    /// <summary>
    /// Получение информации о книге по Id
    /// </summary>
    [HttpGet("book")]
    [ProducesResponseType(typeof(BookModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProfile([FromQuery] Guid id)
    {
        return Ok(await _mediator.Send(new GetBookRequest(id)));
    }
}