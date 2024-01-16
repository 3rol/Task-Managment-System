using Microsoft.EntityFrameworkCore;
using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Interfaces;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskItemService> _logger;
        private readonly TaskManagmentContext _context;

        public TaskItemService(ITaskItemRepository taskItemRepository, IMapper mapper, TaskManagmentContext context, ILogger<TaskItemService> logger)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
            _context = context;
            _logger = logger;
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

        public async Task<TaskItemDto> AddTaskItem(AddTaskItemDto taskItemDto)
        {
            try
            {
                var taskItem = _mapper.Map<TaskItem>(taskItemDto);
                taskItem.UserId = 1;
                _context.TaskItems.Add(taskItem);
                await _context.SaveChangesAsync();

                return _mapper.Map<TaskItemDto>(taskItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the entity changes: {Message}", ex.InnerException?.Message);
                throw; 
            }
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
