using Medic.API.DTOs;
using Medic.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medic.API.Controllers
{
    public class AccountController(IAccountService accountService) : BaseController
    {
        private readonly IAccountService accountService = accountService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerUser)
        {
            try
            {
                var user = await accountService.Register(registerUser);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto login)
        {
            try
            {
                var user = await accountService.Login(login);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });                
            }
        }

        [HttpGet("order-number")]
        public async Task<ActionResult<int>> GetOrderNumber()
        {
            try
            {
                var nextOrder = await accountService.GetOrderNumber();
                return Ok(nextOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
