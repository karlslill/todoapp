using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence.Repositories;

public class ToDoTaskRepository : BaseRepository<ToDoTask>, IToDoTaskRepository
{
    public ToDoTaskRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<ToDoTask>> GetTasksByDueDateAsync(DateTime dueDate)
    {
        return await _dbSet.Where(t => t.DueDate.Date == dueDate.Date).ToListAsync();
    }

    public async Task<IEnumerable<ToDoTask>> SearchTasksAsync(string searchTerm)
    {
        return await _dbSet
            .Where(t => t.Title.Contains(searchTerm) || t.Description.Contains(searchTerm))
            .ToListAsync();
    }
}