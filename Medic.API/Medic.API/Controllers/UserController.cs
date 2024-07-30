using Medic.API.Interfaces;
using Medic.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medic.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult> GetUserDetails(int id)
        {
            var user = await userService.GetUserDetails(id);
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody]RegisterUserDto registerUser)
        {
            try
            {
                await userService.RegisterUser(registerUser);
                return Ok(new { message = "User registered." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("block/{id}")]
        public async Task<IActionResult> BlockUser(int id)
        {
            try
            {
                await userService.BlockUser(id);
                return Ok(new { message = "User has been blocked." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }
    }
}
