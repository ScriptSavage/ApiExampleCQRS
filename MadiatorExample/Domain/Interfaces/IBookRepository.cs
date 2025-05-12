using Domain.Entities;

namespace Domain.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync();
    
    Task<int> AddNewBookAsync(Book book);
    
    Task<Book> GetBookDetailsAsync(int bookId);
}