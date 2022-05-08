using Server.Models;

namespace Server.Repositories.Interfaces {
    public interface IUserRepository {
        Task<AppUser> GetUser(string username);
        Task AddUser(AppUser user);
    }
}
