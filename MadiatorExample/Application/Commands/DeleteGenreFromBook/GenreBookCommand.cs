using Domain.DTO;
using MediatR;

namespace Application.Commands.DeleteGenreFromBook;

public class GenreBookCommand  : GenreBookDto , IRequest;