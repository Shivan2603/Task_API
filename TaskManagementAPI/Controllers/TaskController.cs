using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Data;
using TaskManagementApp.Models;

namespace TaskManagementApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public TasksController(TaskDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppTask>>> GetTasks()
            => await _context.Tasks.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<AppTask>> GetTask(int id)
            => await _context.Tasks.FindAsync(id) is AppTask task ? task : NotFound();

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, AppTask task)
        {
            if (id != task.Id) return BadRequest();

            _context.Entry(task).State = EntityState.Modified;
            task.UpdatedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AppTask>> PostTask(AppTask task)
        {
            task.CreatedAt = task.UpdatedAt = DateTime.UtcNow;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool TaskExists(int id) => _context.Tasks.Any(e => e.Id == id);
    }
}