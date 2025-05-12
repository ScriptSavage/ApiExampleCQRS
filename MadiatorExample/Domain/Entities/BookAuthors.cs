using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[PrimaryKey(nameof(BookId),nameof(AuthorId))]
public class BookAuthors
{
    public int BookId { get; set; }
    [ForeignKey(nameof(BookId))]
    public Book Book { get; set; } = null!;

    public int AuthorId { get; set; }
    [ForeignKey(nameof(AuthorId))]
    public Author Author { get; set; } = null!;
}