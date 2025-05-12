using Domain.DTO;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries.GetAllGenres;

public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, IEnumerable<GenreDto>>
{
    private readonly IGenreRepository _genreRepository;

    public GetGenresQueryHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<GenreDto>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
    {
        var genres = await _genreRepository.GetAllGenres();
        var genreDtos = genres.Select(e => new GenreDto()
        {
            Name = e.Name,
        });
       
        return genreDtos;
    }
}