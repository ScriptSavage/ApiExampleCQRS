using Domain.Entities;

namespace Domain.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync();
    
    Task<int> AddNewBookAsync(Book book);
    
    Task<Book> GetBookDetailsAsync(int bookId);
    
    Task<Book> GetBookByIdAsync(int bookId);
    
    Task<bool> DoesBookExistAsync(int bookId);
    
    Task<int> GetBookIdByTitleAsync(string title);
    
    
    Task<int> DeleteGenreFromBookAsync(int bookId, int genreId);

    Task<int> AddGenreToBookAsync(BookGenre bookGenre);
    
    Task<bool> DoesGenreExistAsync(int genreId);
}