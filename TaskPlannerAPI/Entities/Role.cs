using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TaskPlanner.Entities;

[Table("roles")]

public class Role// : IdentityRole<int>
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Column("Name")]
    [Required]
    public string Name { get; set; } = default!;
    
    [NotMapped]
    [ForeignKey(nameof(User.UserRole))]
    public virtual IList<User> Users { get; set; } = default!;
}