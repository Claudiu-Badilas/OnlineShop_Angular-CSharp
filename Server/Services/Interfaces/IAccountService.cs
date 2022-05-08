using Server.Models;

namespace Server.Services.Interfaces {
    public interface IAccountService {

        public Task RegisterUser(RegisterDto registerDto);
        public Task<AppUser> LoginUser(LoginDto loginDto);
    }
}
