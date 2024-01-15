using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskItem, TaskItemDto>();

            CreateMap<TaskItem, UpdateTaskItemDto>();

            CreateMap<TaskItemDto, TaskItem>();
        }
    }
}
