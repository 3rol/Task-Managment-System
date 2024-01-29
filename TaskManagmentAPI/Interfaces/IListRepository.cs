using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Interfaces
{
    public interface IListRepository
    {
        Task<List<ListDto>> GetAllLists();
        Task<ListDto> GetListByUserId(int userId);
        Task<ListDto> GetListById(int id);
        Task<List> AddList(AddListDto addListDto, int userId);
        Task<ListDto> UpdateList(int id, UpdateListDto updateListDto);
        Task<bool> DeleteList(int id);
    }
}
