using Server.Models;

namespace Server.Repositories.Interfaces {
    public interface IUserRepository {
        Task<AppUser> GetUser(string username);
        Task AddUser(string username, byte[] passwordhash, byte[] passwordSalt);
    }
}
