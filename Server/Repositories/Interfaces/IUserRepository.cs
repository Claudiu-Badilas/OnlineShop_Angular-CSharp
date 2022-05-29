using Server.Models;

namespace Server.Repositories.Interfaces {
    public interface IUserRepository {
        Task<AppUser> GetUser(string username);
        Task<AppUser> GetUserById(long userId);
        Task AddUser(AppUser user);
    }
}
