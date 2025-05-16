using Application.Commands.CreateNewUser;
using Application.Commands.LoginUser;
using Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] CreateNewUserCommand command)
    {
       await _mediator.Send(command);
       return StatusCode(StatusCodes.Status201Created);
    }
    
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { token = result });
    }
}