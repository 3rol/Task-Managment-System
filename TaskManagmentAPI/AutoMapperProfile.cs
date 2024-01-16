using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskItem, TaskItemDto>();
            CreateMap<TaskItemDto, TaskItem>();

            CreateMap<UpdateTaskItemDto, TaskItem>();
            CreateMap<TaskItem, UpdateTaskItemDto>();

            
            CreateMap<AddTaskItemDto, TaskItem>();
        }
    }
}
