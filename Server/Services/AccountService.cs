using Server.Configuration.Interfaces;
using Server.Models;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Server.Services {
    public class AccountService : IAccountService {
        private readonly IUserRepository _userRepo;

        public AccountService(IUserRepository userRepo) {
            _userRepo = userRepo;
        }

        public async Task RegisterUser(RegisterDto registerDto) {
            using var hmac = new HMACSHA512();

            await _userRepo.AddUser(new AppUser {
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
            });
        }

        public async Task<AppUser> LoginUser(LoginDto loginDto) {
            var appUser = await _userRepo.GetUser(loginDto.Username);

            if (appUser == null) return null;

            if (!IsValidPassword(loginDto, appUser)) return null;

            return appUser;
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
