using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentAPI.Dtos;
using TaskManagmentAPI.Interfaces;
using TaskManagmentAPI.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TaskManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private readonly IListService _listService;
        

        public ListsController(IListService listService)
        {
            _listService = listService;
            
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            

            throw new InvalidOperationException("Unable to determine the current user's UserId.");
        }

        [HttpGet(Name = "GetLists")]
        [Authorize]
        public async Task<ActionResult<List<ListDto>>> GetAllLists()
        {
            try
            {
                return Ok(await _listService.GetAllLists());
            }
            catch
            {
                
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ListDto>> GetListById(int id)
        {
            try
            {
                var list = await _listService.GetListById(id);
                return Ok(list);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ListDto>> AddList(AddListDto addListDto)
        {
            try
            {
                int userId = GetCurrentUserId();
                var newList = await _listService.AddList(addListDto, userId);
                return CreatedAtAction(nameof(GetListById), new { id = newList.Id }, newList);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<ListDto>> UpdateList(int id, UpdateListDto updateListDto)
        {
            try
            {
                var updatedList = await _listService.UpdateList(id, updateListDto);
                if (updatedList == null)
                {
                    return NotFound();
                }
                return Ok(updatedList);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteList(int id)
        {
            try
            {
                var success = await _listService.DeleteList(id);
                if (!success)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch 
            {
                
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
