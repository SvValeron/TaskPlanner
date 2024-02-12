using TaskPlanner.Entities;

namespace TaskPlanner.InitDataFactory;

public class TestDataFactory : IDataFactory
{
    public User[] GetUsers()
    {
        return new User[]
        {
            new()
            {
                Id = 1, 
                FirstName = "Valerii", 
                LastName = "Sviatetskyi", 
                Age = 18, 
                PhoneNumber = "+380974187801",
                UserRole = 1
            }
        };
    }
    public UserTask[] GetUserTasks()
    {
        return new UserTask[]
        {
            new()
            {
                Id = 1, 
                UserId = 1,
                Name = "Pokakaty",
                Description = null
            }
        };
    }
    public Role[] GetRoles()
    {
        return new Role[]
        {
            new()
            {
                Id = 1, 
                Name = "admin",
            }
        };
    }
}