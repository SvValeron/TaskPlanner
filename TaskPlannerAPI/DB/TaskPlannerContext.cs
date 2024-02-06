using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using TaskPlanner.Entities;

namespace TaskPlanner.DB;

public class TaskPlannerContext: DbContext
{
    public DbSet<UserTask> UserTasks { get; set; }
    public DbSet<User> Users { get; set; }

    public const string DbPath = "taskplanner.db";

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    public TaskPlannerContext() 
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}
