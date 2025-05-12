using Domain.DTO;
using MediatR;

namespace Application.Commands.CreateAuthor;

public class CreateAuthorCommand : AuthorDto , IRequest;
