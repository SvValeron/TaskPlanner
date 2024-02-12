using TaskPlanner.Entities;

namespace TaskPlanner.InitDataFactory;

public interface IDataFactory
{
    User[] GetUsers();
    UserTask[] GetUserTasks();
    Role[] GetRoles();

    // TODO: Try to add
    // a generic method Get<T>()
    // or
    // a method Get(Type t) and a extension method Get<T>(this IDataFactory factory) => factory.Get(typeof(T))
}