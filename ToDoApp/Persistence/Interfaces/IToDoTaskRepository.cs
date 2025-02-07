using Domain;

namespace Persistence.Interfaces;

public interface IToDoTaskRepository : IBaseRepository<ToDoTask>
{
    Task<IEnumerable<ToDoTask>> GetTasksByDueDateAsync(DateTime dueDate);
    Task<IEnumerable<ToDoTask>> SearchTasksAsync(string searchTerm);
}