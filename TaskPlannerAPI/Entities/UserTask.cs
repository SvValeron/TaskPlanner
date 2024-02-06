using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskPlanner.Entities;

[Table("user_task")]
public class UserTask
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }
}
