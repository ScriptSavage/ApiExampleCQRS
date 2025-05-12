using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Book
{
    [Key]
    public int BookId { get; private set; }
    
    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = null!;
    
    [Required] 
    public int PageNumbers { get; set; }
    
    
    public ICollection<BookAuthors> BooksAuthors { get; set; } = new HashSet<BookAuthors>();
    public ICollection<BookGenre> BookGenres { get; set; } = new HashSet<BookGenre>();


}