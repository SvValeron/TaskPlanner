using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TaskPlanner.Data;
using TaskPlanner.Entities;
using TaskPlanner.InitDataFactory;

namespace TaskPlanner;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAuthentication();
        services.AddDbContext<TaskPlannerContext>();
        services.AddSingleton<IDataFactory, TestDataFactory>();
        /*services
            .AddIdentity<User, Role>()
            .AddEntityFrameworkStores<TaskPlannerContext>()
            .AddUserManager<UserManager<User>>()
            .AddRoleManager<RoleManager<Role>>()
            .AddSignInManager<SignInManager<User>>();*/

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //app.UseWelcomePage();
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

    }
}