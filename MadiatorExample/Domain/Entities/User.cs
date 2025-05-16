using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
public class User
{
    [Key]
    public Guid UserId { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string HashedPassword { get; set; } = string.Empty;


    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
}