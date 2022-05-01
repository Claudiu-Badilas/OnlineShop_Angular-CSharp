using Server.Models;

namespace Server.Configuration.Interfaces {
    public interface ITokenService {
        string CreateToken(AppUser user);
    }
}
