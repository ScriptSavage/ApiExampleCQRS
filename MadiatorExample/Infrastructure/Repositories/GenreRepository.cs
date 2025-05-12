using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly ProjectContext _context;

    public GenreRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<int> AddNewGenre(Genre genre)
    {
        await _context.Genres.AddAsync(genre);
        var commit = await _context.SaveChangesAsync();
        return commit;
    }

    public async Task<List<Genre>> GetAllGenres()
    {
        var data = await _context.Genres.ToListAsync();
        return data;
    }

    public async Task<List<Genre>> GetAllGenresByIdAsync(IEnumerable<int> genresId)
    {
        return await _context.Genres
            .Where(e=>genresId.Contains(e.GenreId))
            .ToListAsync();
    }
}