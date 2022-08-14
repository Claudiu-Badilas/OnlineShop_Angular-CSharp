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
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserRequest registerDto) {
            try {
                var data = await _userRepo.IsExistingUser(registerDto.Email);
                if (data) {
                    return BadRequest("Email is already used!");
                }
                await _accService.RegisterUser(registerDto);
                return Ok("User successfully saved");
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserRequest loginDto) {
            var user = await _accService.LoginUser(loginDto);
            if (user == null) {
                return Unauthorized("Invalid Email or Password");
            }

            return Ok(new {
                user = user,
                token = _tokenService.CreateToken(user)
            });
        }
    }
}
