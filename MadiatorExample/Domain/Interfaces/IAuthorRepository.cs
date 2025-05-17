using Domain.Entities;

namespace Domain.Interfaces;

public interface IAuthorRepository
{
    Task<int> CreateAuthorAsync(Author author);

    Task<List<Author>> GetAllAuthorsByIdAsync(IEnumerable<int> AuthorsId);
    
   

}