using System.ComponentModel.DataAnnotations;

namespace Domain.DTO;

public class AuthorDto
{
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(150)]
    public string LastName { get; set; } = null!;
    
}