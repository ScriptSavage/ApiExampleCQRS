using Application.Commands.CreateGenre;
using Application.Queries.GetAllGenres;
using Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/genres")]
public class GenreController : ControllerBase
{
    private readonly IMediator _mediator;

    public GenreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGenre([FromBody]CreateGenreCommand command)
    {
      var result = await _mediator.Send(command);
      return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGenres()
    {
        var result = await _mediator.Send(new GetGenresQuery());
        return Ok(result);
    }
}