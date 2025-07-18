using System.ComponentModel.DataAnnotations;
namespace ProductInventory.Api.Models;
public class User
{
    [Key]
    public Guid Id { get; set;}
    [Required]
    [MaxLength(50)]
    public required string Username {get; set;}
    [Required]
    public string PasswordHash { get; set;}

    public string Role { get; set;}
}