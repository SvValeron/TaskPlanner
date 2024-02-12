using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TaskPlanner.Entities;
using TaskPlanner.InitDataFactory;


namespace TaskPlanner.Data;

public class TaskPlannerContext : DbContext//IdentityDbContext<User, Role, int>
{
    /*public TaskPlannerContext(DbContextOptions<TaskPlannerContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }*/
    private readonly IDataFactory _dataFactory;
    
    
    public DbSet<Role> Roles { get; set; } = default!;
    public DbSet<UserTask> UserTasks { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;

    public const string DbPath = "DB/taskplanner.db";

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    public TaskPlannerContext(IDataFactory dataFactory)
    {
        _dataFactory = dataFactory;
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<User>().HasData(_dataFactory.GetUsers());
        modelBuilder.Entity<UserTask>().HasData(_dataFactory.GetUserTasks());
        modelBuilder.Entity<Role>().HasData(_dataFactory.GetRoles());*/
        
        /*HasData(typeof(User),_dataFactory.GetUsers());
        HasData(typeof(UserTask),_dataFactory.GetUserTasks());
        HasData(typeof(Role),_dataFactory.GetRoles());
        
        HasDataGeneric<User>(_dataFactory.GetUsers());
        HasDataGeneric<UserTask>(_dataFactory.GetUserTasks());
        HasDataGeneric<Role>(_dataFactory.GetRoles());*/
        
        HasData(_dataFactory.GetRoles());
        HasData(_dataFactory.GetUsers());
        HasData(_dataFactory.GetUserTasks());

        /*void HasData(Type type, object[] entities)
        {
            modelBuilder.Entity(type).HasData(entities);
        }

        void HasDataGeneric<T>(object[] entities) where T: class
        {
            modelBuilder.Entity<T>().HasData(entities);
        }*/
        
        void HasData<T>(T[] entities) where T: class
        {
            modelBuilder.Entity<T>().HasData(entities);
        }
    }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<IdentityRole>();
        modelBuilder.Ignore<IdentityUserToken<string>>();
        modelBuilder.Ignore<IdentityUserRole<string>>();
        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Ignore<IdentityUserClaim<string>>();
        modelBuilder.Ignore<IdentityRoleClaim<string>>();
        modelBuilder.Entity<IdentityUser>()
            .Ignore(c => c.UserName)
            .Ignore(c => c.NormalizedUserName)
            .Ignore(c => c.Email)
            .Ignore(c => c.NormalizedEmail)
            .Ignore(c => c.EmailConfirmed)
            .Ignore(c => c.PasswordHash)
            .Ignore(c => c.SecurityStamp)
            .Ignore(c => c.ConcurrencyStamp)
            .Ignore(c => c.PhoneNumberConfirmed)
            .Ignore(c => c.TwoFactorEnabled)
            .Ignore(c => c.LockoutEnd)
            .Ignore(c => c.LockoutEnabled)
            .Ignore(c => c.AccessFailedCount);
    }*/
}