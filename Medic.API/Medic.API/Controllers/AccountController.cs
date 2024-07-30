using Medic.API.Interfaces;
using Medic.API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medic.API.Controllers
{
    [ApiController]
    [Route("/")]
    //[Authorize(Roles = "Administrator")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;            
        }

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
    }
}
