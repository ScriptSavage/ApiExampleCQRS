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

    public async Task<Book> GetBookByIdAsync(int bookId)
    {
        var book = await _context.Books
            .FirstOrDefaultAsync(e => e.BookId == bookId);

        return book;
    }

    public async Task<bool> DoesBookExistAsync(int bookId)
    {
        var doesExists = await _context.Books
            .AnyAsync(e => e.BookId == bookId);
        
        return doesExists;
    }

    public async Task<int> GetBookIdByTitleAsync(string title)
    {
        var book = await _context.Books
            .FirstOrDefaultAsync(e => e.Title == title);

        return book.BookId;
    }

    public async Task<int> DeleteGenreFromBookAsync(int bookId, int genreId)
    {
        var data = await _context.BookGenres
            .FirstOrDefaultAsync(e => e.BookId == bookId && e.GenreId == genreId);
        
        _context.BookGenres.Remove(data);

       return await _context.SaveChangesAsync();
    }

    public async Task<int> AddGenreToBookAsync(BookGenre bookGenre)
    {
         await _context.BookGenres.AddAsync(bookGenre);
         return await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesGenreExistAsync(int genreId)
    {
        var doesGenreExists = await _context.Books
            .Include(e=>e.BookGenres)
            .AnyAsync(e => e.BookGenres.Any(e=>e.GenreId == genreId));
        
        return doesGenreExists;
    }
}