using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly ProjectContext _context;

    public AuthorRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAuthorAsync(Author author)
    {
        await _context.Authors.AddAsync(author);
        var commit  = await _context.SaveChangesAsync();
        return commit;
    }

    public async Task<List<Author>> GetAllAuthorsByIdAsync(IEnumerable<int> authorsId)
    {
        return  await _context.Authors
            .Where(e => authorsId.Contains(e.AuthorId))
            .ToListAsync();
    }

   
}