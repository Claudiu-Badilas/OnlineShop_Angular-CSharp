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

        public async Task RegisterUser(RegisterUserRequest registerDto) {
            using var hmac = new HMACSHA512();

            await _userRepo.AddUser(new AppUser {
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                Email = registerDto.Email,
                JoinDate = DateTime.UtcNow,
                LastLogin = DateTime.UtcNow,
                IsActive = true,
                RoleId = (int)Role.USER
            });
        }

        public async Task<AppUser> LoginUser(LoginUserRequest loginDto) {
            var isExistingUser = await _userRepo.IsExistingUser(loginDto.Email);
            if (!isExistingUser) return null;

            var user = await _userRepo.GetUserByEmail(loginDto.Email);
            var isPasswordValid = IsPasswordValid(loginDto, user);
            if (!isPasswordValid) return null;

            return user;
        }

        private bool IsPasswordValid(LoginUserRequest loginDto, AppUser appUser) {
            using var hmac = new HMACSHA512(appUser.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++) {
                if (computedHash[i] != appUser.PasswordHash[i]) {
                    return false;
                }
            }
            return true;
        }
    }
}
