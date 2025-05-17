using Domain.DTO;
using MediatR;

namespace Application.Commands.AddGenreToBook;

public class AddGenreToBookCommand : GenreBookDto , IRequest;