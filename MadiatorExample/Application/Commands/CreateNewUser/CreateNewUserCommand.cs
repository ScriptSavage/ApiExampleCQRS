using Domain.DTO;
using MediatR;

namespace Application.Commands.CreateNewUser;

public class CreateNewUserCommand : UserDto ,IRequest;