using Application.Commands.CreateBook;
using Application.Queries.GetAllBooks;
using Application.Queries.GetBookDetails;
using Domain.DTO;
using MediatR;
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
    public async Task<IActionResult> AddNewBook(CreateBookCommand command)
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
}