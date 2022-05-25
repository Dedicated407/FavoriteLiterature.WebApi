using FavoriteLiterature.Api.Entities.Enums;
using FavoriteLiterature.Api.Entities.Requests.Books;
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
    public async Task<IActionResult> Add([FromBody] AddBookRequest request) =>
        Ok(await _mediator.Send(request));
}