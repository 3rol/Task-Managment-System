using Microsoft.AspNetCore.Mvc;
using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Interfaces;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;

        public TaskItemsController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItemDto>>> GetAllTaskItems()
        {
            return Ok(await _taskItemService.GetAllTaskItems());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetTaskItemById(int id)
        {
            try
            {
                var taskItem = await _taskItemService.GetTaskItemById(id);
                return Ok(taskItem);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> AddTask(TaskItemDto taskItemDto)
        {
            try
            {
                var newTaskItem = await _taskItemService.AddTaskItem(taskItemDto);
                return CreatedAtAction(nameof(GetTaskItemById), new { id = newTaskItem.Id }, newTaskItem);
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., user not found)
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskItemDto>> UpdateTask(int id, UpdateTaskItemDto updateTaskItemDto)
        {
            try
            {
                var updatedTaskItem = await _taskItemService.UpdateTaskItem(id, updateTaskItemDto);
                if (updatedTaskItem == null)
                {
                    return NotFound();
                }
                return Ok(updatedTaskItem);
            }
            catch (Exception ex)
            {
                // Handle exception
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var success = await _taskItemService.DeleteTaskItem(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
