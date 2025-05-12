namespace Domain.DTO;

public class BookDetailsDto
{
    public string Title { get; set; } = null!;
    
    public int PageNumbers { get; set; }

    public ICollection<AuthorDetailsDto> AuthorDetailsDtos { get; set; } = new HashSet<AuthorDetailsDto>();
    public ICollection<GenreDetailsDto> GenreDetailsDtos { get; set; } = new HashSet<GenreDetailsDto>();
}


public class AuthorDetailsDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}

public class GenreDetailsDto
{
    public string Name { get; set; } = null!;
}