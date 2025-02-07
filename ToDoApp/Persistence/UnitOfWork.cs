using Persistence.Interfaces;
using Persistence.Repositories;

namespace Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IToDoTaskRepository ToDoTasks { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        ToDoTasks = new ToDoTaskRepository(context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}