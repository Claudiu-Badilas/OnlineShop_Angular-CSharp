using Server.Models;

namespace Server.Services.Interfaces {
    public interface IAccountService {

        public Task<UserDto> RegisterUser(RegisterDto registerDto);
        public Task<UserDto> LoginUser(LoginDto loginDto);
    }
}
