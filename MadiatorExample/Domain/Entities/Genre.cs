using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Genre
{
    [Key]
    public int GenreId { get; set; }

    [Required] [MaxLength(150)] 
    public string Name { get; set; } = null!;

    public ICollection<BookGenre> BookGenres { get; set; } = new HashSet<BookGenre>();
}