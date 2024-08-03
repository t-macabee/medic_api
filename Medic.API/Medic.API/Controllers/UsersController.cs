using MapsterMapper;
using Medic.API.DTOs;
using Medic.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Medic.API.Controllers
{
    public class UsersController(IUserService userService) : BaseController
    {
        private readonly IUserService userService = userService;

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditUser(int id, [FromBody] MemberEditDto userEditDto)
        {
            try
            {
                var updatedUser = await userService.EditUser(id, userEditDto);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("toggle-status/{id}")]
        public async Task<IActionResult> BlockUser(int id)
        {
            try
            {
                await userService.ToggleUserStatus(id);
                return Ok(new { message = "User has been toggled." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }      
    }
}
