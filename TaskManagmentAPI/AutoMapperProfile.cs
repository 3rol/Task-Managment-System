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

            CreateMap<List, ListDto>();
            CreateMap<ListDto, List>();

            CreateMap<UpdateListDto, List>();
            CreateMap<List, UpdateListDto>();

            CreateMap<AddListDto, List>();
        }
    }
}
