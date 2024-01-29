using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Interfaces;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Services
{
    public class ListService : IListService
    {
        private readonly IListRepository _listRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ListService> _logger;

        public ListService(IListRepository listRepository, IMapper mapper, ILogger<ListService> logger)
        {
            _listRepository = listRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ListDto>> GetAllLists()
        {
            try
            {
                var lists = await _listRepository.GetAllLists();
                return _mapper.Map<List<ListDto>>(lists);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all lists: {Message}", ex.InnerException?.Message);
                throw;
            }
        }

        public async Task<int> GetListIdByUserId(int userId)
        {
            try
            {
                var list = await _listRepository.GetListByUserId(userId);

                if (list != null)
                {
                    return list.Id;
                }

                _logger.LogError("List not found for user with UserId: {UserId}", userId);
                return -1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetListIdByUserId: {Message}", ex.Message);
                throw;
            }
        }

        public async Task<ListDto> GetListById(int id)
        {
            try
            {
                var list = await _listRepository.GetListById(id);
                return _mapper.Map<ListDto>(list);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, "List not found for id: {Id}", id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting list by id: {Message}", ex.Message);
                throw;
            }
        }

        public async Task<ListDto> AddList(AddListDto addListDto, int userId)
        {
            try
            {
                var createdList = await _listRepository.AddList(addListDto, userId);
                return _mapper.Map<ListDto>(createdList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a list: {Message}", ex.InnerException?.Message);
                throw;
            }
        }

        public async Task<ListDto> UpdateList(int id, UpdateListDto updateListDto)
        {
            try
            {
                var updatedList = await _listRepository.UpdateList(id, updateListDto);
                return _mapper.Map<ListDto>(updatedList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a list: {Message}", ex.InnerException?.Message);
                throw;
            }
        }

        public async Task<bool> DeleteList(int id)
        {
            try
            {
                return await _listRepository.DeleteList(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a list: {Message}", ex.InnerException?.Message);
                throw;
            }
        }
    }
}
