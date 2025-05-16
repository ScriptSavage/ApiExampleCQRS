using Domain.DTO;
using MediatR;

namespace Application.Commands.LoginUser;

public class LoginUserCommand : UserDto, IRequest<string>;