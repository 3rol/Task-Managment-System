using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagmentAPI.Dtos;

public interface IListService
{
    Task<List<ListDto>> GetAllLists();
    Task<int> GetListIdByUserId(int userId);
    Task<ListDto> GetListById(int id);
    Task<ListDto> AddList(AddListDto addListDto, int userId);
    Task<ListDto> UpdateList(int id, UpdateListDto updateListDto);
    Task<bool> DeleteList(int id);
}