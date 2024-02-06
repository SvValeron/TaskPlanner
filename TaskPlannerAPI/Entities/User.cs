using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskPlanner.Entities;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [Required]
    public string Name { get; set; } = null!;

    [Column("surname")]
    [Required]
    public string Surname { get; set; } = null!;

    [Column("age")]
    [Required]
    public int Age { get; set; }

    [Column("phone_number")]
    [Required]
    public string PhoneNumber { get; set; } = null!;

    [NotMapped]
    [ForeignKey(nameof(UserTask.UserId))]
    public virtual IList<UserTask> UserTasks { get; set; }
}
