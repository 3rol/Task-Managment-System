using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagmentAPI.Dtos;

namespace TaskManagmentAPI.Interfaces
{
    public interface ITaskItemService
    {
        Task<List<TaskItemDto>> GetAllTaskItems();
        Task<TaskItemDto> GetTaskItemById(int id);
        Task<List<TaskItemDto>> GetTaskItemsByUserId(int userId);
        Task<TaskItemDto> AddTaskItem(AddTaskItemDto taskItemDto, int userId);
        Task<TaskItemDto> UpdateTaskItem(int id, UpdateTaskItemDto updateTaskItemDto);
        Task<bool> DeleteTaskItem(int id);
    }
}
