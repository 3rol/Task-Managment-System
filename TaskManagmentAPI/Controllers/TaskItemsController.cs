using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Interfaces;
using TaskManagmentAPI.Models;
using System.Linq;
using System.Security.Claims;

namespace TaskManagmentAPI.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;
        

        public TaskItemsController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
            
        }
        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            throw new InvalidOperationException("Unable to determine the current user's UserId.");
        }

        [HttpGet(Name = "GetTasks"), Authorize]
        

        public async Task<ActionResult<List<TaskItemDto>>> GetAllTaskItems()
        {
            int userId = GetCurrentUserId();
            return Ok(await _taskItemService.GetAllTaskItems());
        }

        [HttpGet("{id}"), Authorize]
        

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

        [HttpGet("user"), Authorize]
        public async Task<ActionResult<List<TaskItemDto>>> GetTaskItemsByUserId()
        {
            int userId = GetCurrentUserId();
            var taskItems = await _taskItemService.GetTaskItemsByUserId(userId);
            return Ok(taskItems);
        }

        [HttpPost, Authorize]
        
        
        public async Task<ActionResult<TaskItemDto>> AddTask(AddTaskItemDto addTaskItem)
        {
            try
            {
                int userId = GetCurrentUserId();
                var newTaskItem = await _taskItemService.AddTaskItem(addTaskItem, userId);
                return CreatedAtAction(nameof(GetTaskItemById), new { id = newTaskItem.Id }, newTaskItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}"), Authorize]
        
        public async Task<ActionResult<TaskItemDto>> UpdateTask(int id, UpdateTaskItemDto updateTaskItem)
        {
            try
            {
                var updatedTaskItem = await _taskItemService.UpdateTaskItem(id, updateTaskItem);
                if (updatedTaskItem == null)
                {
                    return NotFound();
                }
                return Ok(updatedTaskItem);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}"), Authorize]
        
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
