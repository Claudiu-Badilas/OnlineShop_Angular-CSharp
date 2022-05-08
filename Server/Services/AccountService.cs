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

        public async Task<UserDto> LoginUser(LoginDto loginDto) {
            var appUser = await _userRepo.GetUser(loginDto.Username);

            if (appUser == null) return null;
            if (!IsValidPassword(loginDto, appUser)) return null;

            return new UserDto {
                Username = appUser.UserName,
                Token = _tokenService.CreateToken(appUser),
                EmailAddress = appUser.EmailAddress,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                JoinDate = appUser.JoinDate,
                LastLogin = appUser.LastLogin,
                IsActive = appUser.IsActive,
                Role = new Role { Id = appUser.Role.Id, Name = appUser.Role.Name }
            };
        }

        private bool IsValidPassword(LoginDto loginDto, AppUser appUser) {
            using var hmac = new HMACSHA512(appUser.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++) {
                if (computedHash[i] != appUser.PasswordHash[i]) return false;
            }
            return true;
        }
    }
}
