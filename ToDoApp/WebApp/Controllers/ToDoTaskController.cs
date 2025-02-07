using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToDoTaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ToDoTask
        [HttpGet]
        public async Task<IActionResult> GetToDoTasks([FromQuery] string? search, [FromQuery] bool? isDone, [FromQuery] DateTime? dueDate)
        {
            // Filtering logic here
            var tasks = await _unitOfWork.ToDoTasks.GetAllAsync();

            if (isDone.HasValue)
                tasks = tasks.Where(t => t.IsDone == isDone.Value);

            if (!string.IsNullOrEmpty(search))
                tasks = tasks.Where(t => t.Title.Contains(search) || t.Description.Contains(search));

            if (dueDate.HasValue)
                tasks = tasks.Where(t => t.DueDate.Date == dueDate.Value.Date);

            return Ok(tasks);
        }

        // GET: api/ToDoTask/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoTask(int id)
        {
            var task = await _unitOfWork.ToDoTasks.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // POST: api/ToDoTask
        [HttpPost]
        public async Task<IActionResult> CreateToDoTask([FromBody] ToDoTask task)
        {
            if (task == null)
                return BadRequest();

            await _unitOfWork.ToDoTasks.AddAsync(task);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetToDoTask), new { id = task.Id }, task);
        }

        // PUT: api/ToDoTask/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoTask(int id, [FromBody] ToDoTask task)
        {
            if (task == null || id != task.Id)
                return BadRequest();

            var existingTask = await _unitOfWork.ToDoTasks.GetByIdAsync(id);

            if (existingTask == null)
                return NotFound();

            // Update properties
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.DueDate = task.DueDate;
            existingTask.IsDone = task.IsDone;

            _unitOfWork.ToDoTasks.Update(existingTask);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        // DELETE: api/ToDoTask/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoTask(int id)
        {
            var task = await _unitOfWork.ToDoTasks.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            _unitOfWork.ToDoTasks.Delete(task);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}