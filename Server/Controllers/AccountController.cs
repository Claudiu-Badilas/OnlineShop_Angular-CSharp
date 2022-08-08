using Microsoft.AspNetCore.Mvc;
using Server.Configuration.Interfaces;
using Server.Models;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace Server.Controllers {

    [Route("api/account")]
    public class AccountController : BaseController {
        private readonly IAccountService _accService;
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accService, IUserRepository userRepo, ITokenService tokenService) {
            _accService = accService;
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterDto registerDto) {
            try {
                if ((await _userRepo.GetUser(registerDto.Username)) != null) return BadRequest("Username was taken");

                await _accService.RegisterUser(registerDto);
                return Ok("User successfully saved");
            } catch (Exception ex) {
                BadRequest(ex.Message);
                return null;
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto) {
            var user = await _accService.LoginUser(loginDto);

            if (user == null) return Unauthorized("Invalid username or password");

            return Ok(new UserDto(user, _tokenService.CreateToken(user)));
        }
    }
}
