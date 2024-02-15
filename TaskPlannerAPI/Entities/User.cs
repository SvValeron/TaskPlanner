using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;

namespace TaskPlanner.Entities;

[Table("users")]
public class User//: IdentityUser<int>
{
    [Key]
    [Column("id")]
    public  int Id { get; set; }

    [Column("name")]
    [Required]
    public string FirstName { get; set; } = default!;

    [Column("surname")]
    [Required]
    public string LastName { get; set; } = default!;

    [Column("age")]
    [Required]
    public int Age { get; set; }

    [Column("phone_number")]
    [Required]
    public string? PhoneNumber { get; set; }
    
    [Column("user_roles")]
    public int UserRole { get; set; }
    [ForeignKey(nameof(UserRole))]
    public virtual Role Role { get; set; } = default!;

    [NotMapped]
    [InverseProperty(nameof(UserTask.UserId))]
    public virtual IList<UserTask> UserTasks { get; set; } = default!;
}
