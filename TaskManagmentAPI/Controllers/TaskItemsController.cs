using Microsoft.AspNetCore.Authorization;
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

        [HttpGet(Name = "GetTasks"), Authorize(Roles = "Member")]
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
        public async Task<ActionResult<TaskItemDto>> AddTask(AddTaskItemDto addTaskItem)
        {
            try
            {
                var newTaskItem = await _taskItemService.AddTaskItem(addTaskItem);
                return CreatedAtAction(nameof(GetTaskItemById), new { id = newTaskItem.Id }, newTaskItem);
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
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
