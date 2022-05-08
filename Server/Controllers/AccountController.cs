using Microsoft.AspNetCore.Mvc;
using Server.Configuration.Interfaces;
using Server.Models;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Server.Controllers {

    [Route("api/account")]
    public class AccountController : BaseController {
        private readonly IAccountService _accService;
        public AccountController(IAccountService accService) {
            _accService = accService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser([FromBody] RegisterDto registerDto) {

            var user = await _accService.RegisterUser(registerDto);

            if (user == null) return BadRequest("Username is taken");

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto) {
            var user = await _accService.LoginUser(loginDto);

            if (user == null) return Unauthorized("Invalid username or password");

            return Ok(user);
        }
    }
}
