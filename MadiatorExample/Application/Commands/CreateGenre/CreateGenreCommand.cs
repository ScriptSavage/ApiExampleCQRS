using Domain.DTO;
using MediatR;

namespace Application.Commands.CreateGenre;

public class CreateGenreCommand : GenreDto , IRequest;