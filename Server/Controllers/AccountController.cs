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

        /*[HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto) {
            var user = await GetUser(loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++) {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDto {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                JoinDate = user.JoinDate,
                LastLogin = user.LastLogin,
                IsActive = user.IsActive,
                Role = new Role { Id = user.Role.Id, Name = user.Role.Name }
            };
        }

        private async Task<AppUser> GetUser(string username) {
            return await _userRepo.GetUser(username);
        }*/
    }
}
