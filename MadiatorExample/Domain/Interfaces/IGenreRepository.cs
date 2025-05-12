using Domain.Entities;

namespace Domain.Interfaces;

public interface IGenreRepository
{
    Task<int> AddNewGenre(Genre genre);
    Task<List<Genre>> GetAllGenres();
    
    Task<List<Genre>> GetAllGenresByIdAsync(IEnumerable<int> genresId);
}