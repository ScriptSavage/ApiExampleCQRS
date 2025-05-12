using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Author
{
    [Key]
    public int AuthorId { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(150)]
    public string LastName { get; set; } = null!;

    public ICollection<BookAuthors> BooksAuthors { get; set; } = new HashSet<BookAuthors>();
}