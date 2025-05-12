using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ProjectContext _context;

    public BookRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        var data = await _context.Books.ToListAsync(); 
        return data;
    }
    

    public async Task<int> AddNewBookAsync(Book book)
    {
       await _context.Books.AddAsync(book);
       return await _context.SaveChangesAsync();
    }

    public async Task<Book> GetBookDetailsAsync(int bookId)
    {
        var data = await _context.Books
            .Include(e=>e.BooksAuthors)
            .ThenInclude(e=>e.Author)
            .Include(e=>e.BookGenres)
            .ThenInclude(e=>e.Genre)
            .FirstOrDefaultAsync(e => e.BookId == bookId);

        if (data is null)
        {
            throw new ApplicationException("Book not found");
        }

        return data;
    }
}