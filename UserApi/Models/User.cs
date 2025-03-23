using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserApi.Enum;

namespace UserApi.Models;

public class User
{
    public User(string firstName, string lastName, string email, string password, RoleEnum role = RoleEnum.User)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Role = role;
    }
    
    public User() {}
    
    [Key]
    public Guid Id { get; set; }

    [Column("firstname")]
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Column("lastname")]
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Column("email")]
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    
    [Column("password")]
    [Required]
    [MaxLength(255)]
    public string Password { get; set; }
    
    [Column("Role")]
    [Required]
    public RoleEnum Role { get; set; }
}