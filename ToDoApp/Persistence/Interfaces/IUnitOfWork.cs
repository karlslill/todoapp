namespace Persistence.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IToDoTaskRepository ToDoTasks { get; }
    Task<int> CompleteAsync();
}