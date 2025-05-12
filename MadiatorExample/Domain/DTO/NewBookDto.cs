namespace Domain.DTO;

public class NewBookDto
{
    public string Title { get; set; } = null!;
    
    public int PageNumbers { get; set; }

    public IEnumerable<int> GenresId { get; set; } = new HashSet<int>();
    public IEnumerable<int> AuthorsId { get; set; } = new HashSet<int>();
}