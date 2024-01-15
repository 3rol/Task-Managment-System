using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<List<TaskItem>> GetAllTaskItems();
        Task<TaskItem> GetTaskItemById(int id);
        Task<TaskItem> AddTaskItem(TaskItemDto taskItemDto);
        Task<TaskItem> UpdateTaskItem(int id, UpdateTaskItemDto updateTaskItemDto);
        Task<bool> DeleteTaskItem(int id);

    }
}
