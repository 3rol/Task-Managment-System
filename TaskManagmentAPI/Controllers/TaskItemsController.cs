using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TaskManagmentAPI.Models;
using TaskManagmentAPI.Dtos;

namespace TaskManagmentAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : Controller
    {
        private readonly TaskManagmentContext _context;

        public TaskItemsController(TaskManagmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> Get()
        {
            return Ok(await _context.TaskItems.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskItem>>> Get(int id)
        {
            var task = await _context.TaskItems
                .Where(t => t.UserId == id)
                .Include(t => t.User)
                .ToListAsync();

            return task;
            
                    
        }

        [HttpPost]
        public async Task<ActionResult<List<TaskItem>>> AddTask(TaskItemDto request)
        {
            var user = await _context.User.FindAsync(request.UserId);
            if (user == null)
                return NotFound();

            var newTaskItem = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                User = user
            };

            _context.TaskItems.Add(newTaskItem);
            await _context.SaveChangesAsync();

            return await Get(newTaskItem.UserId);
                
        }

        [HttpPut]

        public async Task<ActionResult<List<TaskItem>>> UpdateTask(UpdateTaskItemDto request)
        {
            var taskitem = await _context.TaskItems.FindAsync(request.UserId);
            if (taskitem == null)
                return BadRequest("Task not found.");

            taskitem.Title = request.Title;
            taskitem.Description = request.Description;
            taskitem.Priority = request.Priority;
            taskitem.Status = request.Status;

            await _context.SaveChangesAsync();

            return Ok(await _context.TaskItems.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaskItem>>> DeleteTask(int id)
        {
            var taskitem = await _context.TaskItems.FindAsync(id);
            if (taskitem == null)
                return BadRequest("Hero not found.");

            _context.TaskItems.Remove(taskitem);
            await _context.SaveChangesAsync();

            return Ok(await _context.TaskItems.ToListAsync());
        }

    }
}
