using Application.Commands.AddGenreToBook;
using Application.Commands.CreateBook;
using Application.Commands.DeleteGenreFromBook;
using Application.Queries.GetAllBooks;
using Application.Queries.GetBookDetails;
using Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/books")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        return Ok(await _mediator.Send(new GetAllBooksQuery()));
    }

    
    [HttpPost]
    public async Task<IActionResult> AddNewBook([FromBody]CreateBookCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    
    [HttpGet]
    [Route("{bookId}")]
    public async Task<IActionResult> GetBookDetailsById(int bookId)
    {
        var data = await _mediator.Send(new GetBookDetailsQuery(bookId));
        return Ok(data);
    }


    [HttpDelete("deleteGenre")]
    public async Task<IActionResult> DeleteGenreFromBook([FromBody] GenreBookCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status204NoContent);
    }


    [HttpPost("AddGenre")]
    public async Task<IActionResult> AddGenreToBook([FromBody] AddGenreToBookCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status204NoContent);
    }
}