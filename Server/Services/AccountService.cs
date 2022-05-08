using Server.Configuration.Interfaces;
using Server.Models;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Server.Services {
    public class AccountService : IAccountService {

        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;
        public AccountService(IUserRepository userRepo, ITokenService tokenService) {
            _tokenService = tokenService;
            _userRepo = userRepo;
        }

        public async Task<UserDto> RegisterUser(RegisterDto registerDto) {
            var appUser = await _userRepo.GetUser(registerDto.Username);
            if (appUser != null) return null;

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

            return new UserDto {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                JoinDate = user.JoinDate,
                LastLogin = user.LastLogin,
                IsActive = user.IsActive,
                Role = new Role { Id = user.Role.Id, Name = registerDto.Role.Name }
            };
        }

        public Task<UserDto> LoginUser(LoginDto loginDto) {
            throw new NotImplementedException();
        }
    }
}
