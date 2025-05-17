using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class ProjectContext : DbContext
{
    protected ProjectContext()
    {
    }

    public ProjectContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthors> BooksAuthors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }
}