using Server.Models;

namespace Server.Services.Interfaces {
    public interface IAccountService {

        public Task RegisterUser(RegisterUserRequest registerDto);
        public Task<AppUser> LoginUser(LoginUserRequest loginDto);
    }
}
