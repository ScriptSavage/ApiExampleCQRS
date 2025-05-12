using Domain.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Queries.GetAllGenres;

public class GetGenresQuery : IRequest<IEnumerable<GenreDto>>;