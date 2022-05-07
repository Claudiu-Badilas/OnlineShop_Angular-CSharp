using Microsoft.AspNetCore.Mvc;
using Server.Configuration.Interfaces;
using Server.Models;
using Server.Repositories.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Server.Controllers {

    [Route("api/account")]
    public class AccountController : BaseController {
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;
        public AccountController(IUserRepository userRepo, ITokenService tokenService) {
            _tokenService = tokenService;
            _userRepo = userRepo;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto) {
            var appUser = await _userRepo.GetUser(registerDto.Username);
            if (appUser != null) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            AppUser user = new AppUser {
                UserName = registerDto.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                EmailAddress = registerDto.EmailAddress,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                JoinDate = registerDto.JoinDate,
                LastLogin = registerDto.LastLogin,
                IsActive = registerDto.IsActive,
                RoleId = registerDto.Role.Id,
                Role = new Role { Id = registerDto.Role.Id, Name = registerDto.Role.Name }
            };

            await _userRepo.AddUser(user);

            var token = _tokenService.CreateToken(user);

            return new UserDto {
                Username = user.UserName,
                Token = token,
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                JoinDate = user.JoinDate,
                LastLogin = user.LastLogin,
                IsActive = user.IsActive,
                Role = new Role { Id = user.Role.Id, Name = registerDto.Role.Name }
            };
        }

        [HttpPost("login")]
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
        }
    }
}
