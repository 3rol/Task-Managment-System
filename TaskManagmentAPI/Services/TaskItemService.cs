using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Interfaces;
using TaskManagmentAPI.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TaskManagmentAPI.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskItemService> _logger;
        private readonly TaskManagmentContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskItemService(ITaskItemRepository taskItemRepository, IMapper mapper, TaskManagmentContext context, ILogger<TaskItemService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
            _context = context;
            _logger = logger;
          
            _httpContextAccessor = httpContextAccessor;
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

        public async Task<List<TaskItemDto>> GetTaskItemsByUserId(int userId)
        {
            var taskItems = await _taskItemRepository.GetTaskItemsByUserId(userId);
            return _mapper.Map<List<TaskItemDto>>(taskItems);
        }


        public async Task<TaskItemDto> AddTaskItem(AddTaskItemDto taskItemDto, int userId)
        {
            try
            {

                
                var taskItem = _mapper.Map<TaskItem>(taskItemDto);
                taskItem.IsCompleted = false;
                taskItem.UserId = userId;
             
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


        private int GetCurrentUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            _logger.LogError("Unable to determine the current user's UserId. UserIdClaim: {UserIdClaim}", userIdClaim?.Value);

            throw new InvalidOperationException("Unable to determine the current user's UserId.");
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
