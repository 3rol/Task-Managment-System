using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Interfaces;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;

        public TaskItemService(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }

        public async Task<List<TaskItemDto>> GetAllTaskItems()
        {
            var taskItems = await _taskItemRepository.GetAllTaskItems();
            return _mapper.Map<List<TaskItemDto>>(taskItems);
        }

        public async Task<TaskItemDto> GetTaskItemById(int id)
        {
            var taskItem = await _taskItemRepository.GetTaskItemById(id);
            return _mapper.Map<TaskItemDto>(taskItem);
        }

        public async Task<TaskItemDto> AddTaskItem(TaskItemDto taskItemDto)
        {
            var taskItem = _mapper.Map<TaskItem>(taskItemDto);
            
            return _mapper.Map<TaskItemDto>(taskItem);
        }

        public async Task<TaskItemDto> UpdateTaskItem(int id, UpdateTaskItemDto updateTaskItemDto)
        {
            var taskItem = await _taskItemRepository.UpdateTaskItem(id, updateTaskItemDto);
            return _mapper.Map<TaskItemDto>(taskItem);
        }

        public async Task<bool> DeleteTaskItem(int id)
        {
            return await _taskItemRepository.DeleteTaskItem(id);
        }
    }

}
