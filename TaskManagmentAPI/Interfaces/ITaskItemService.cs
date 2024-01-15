using TaskManagmentAPI.Dtos;

namespace TaskManagmentAPI.Interfaces
{
    public interface ITaskItemService
    {
        Task<List<TaskItemDto>> GetAllTaskItems();
        Task<TaskItemDto> GetTaskItemById(int id);
        Task<TaskItemDto> AddTaskItem(TaskItemDto taskItemDto);
        Task<TaskItemDto> UpdateTaskItem(int id, UpdateTaskItemDto updateTaskItemDto);
        Task<bool> DeleteTaskItem(int id);
    }

}
