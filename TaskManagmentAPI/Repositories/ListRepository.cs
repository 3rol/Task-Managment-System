using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Interfaces;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly TaskManagmentContext _context;
        private readonly IMapper _mapper;

        public ListRepository(TaskManagmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ListDto>> GetAllLists()
        {
            var lists = await _context.Lists.ToListAsync();
            return _mapper.Map<List<ListDto>>(lists);
        }

        public async Task<ListDto> GetListById(int id)
        {
            var list = await _context.Lists.FindAsync(id);
            if (list == null)
            {
                throw new KeyNotFoundException("List not found.");
            }
            return _mapper.Map<ListDto>(list);
        }
        public async Task<ListDto> GetListByUserId(int userId)
        {
            return await _context.Lists
                .Where(list => list.UserId == userId)
                .Select(list => _mapper.Map<ListDto>(list))
                .FirstOrDefaultAsync();
        }

        public async Task<List> AddList(AddListDto addListDto, int userId)
        {
            var list = _mapper.Map<List>(addListDto);
            list.UserId = userId; 
            _context.Lists.Add(list);
            await _context.SaveChangesAsync();
            return list;
        }

        public async Task<ListDto> UpdateList(int id, UpdateListDto updateListDto)
        {
            var list = await _context.Lists.FindAsync(id);
            if (list == null)
            {
                return null;
            }
            _mapper.Map(updateListDto, list);
            await _context.SaveChangesAsync();
            return _mapper.Map<ListDto>(list);
        }

        public async Task<bool> DeleteList(int id)
        {
            var list = await _context.Lists.FindAsync(id);
            if (list == null)
            {
                return false;
            }
            _context.Lists.Remove(list);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
