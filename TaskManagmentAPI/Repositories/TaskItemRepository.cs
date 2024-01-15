using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Interfaces;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly TaskManagmentContext _context;
        private readonly IMapper _mapper;

        public TaskItemRepository(TaskManagmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TaskItem>> GetAllTaskItems()
        {
            return await _context.TaskItems.ToListAsync();
        }

        public async Task<TaskItem> GetTaskItemById(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                throw new KeyNotFoundException("TaskItem not found.");
            }
            return taskItem;
        }

        public async Task<TaskItem> AddTaskItem(TaskItemDto taskItemDto)
        {
            var taskItem = _mapper.Map<TaskItem>(taskItemDto);
            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<TaskItem> UpdateTaskItem(int id, UpdateTaskItemDto updateTaskItemDto)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return null;
            }
            _mapper.Map(updateTaskItemDto, taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<bool> DeleteTaskItem(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return false;
            }
            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
