using Medic.API.DTOs;
using Medic.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Roles = "Administrator")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            var user = await userService.GetUserDetails(id);
            return Ok(user);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditUser(int id, [FromBody] UserEditDto userEditDto)
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
