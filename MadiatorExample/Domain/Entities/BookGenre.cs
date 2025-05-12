using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[PrimaryKey(nameof(BookId),nameof(GenreId))]
public class BookGenre
{
    public int BookId { get; set; }
    [ForeignKey(nameof(BookId))]
    public Book Book { get; set; } = null!;

    public int GenreId { get; set; }
    [ForeignKey(nameof(GenreId))]
    public Genre Genre { get; set; } = null!;
}