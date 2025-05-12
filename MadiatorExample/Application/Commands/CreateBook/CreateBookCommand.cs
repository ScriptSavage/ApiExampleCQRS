using Domain.DTO;
using MediatR;

namespace Application.Commands.CreateBook;

public class CreateBookCommand : NewBookDto, IRequest;
