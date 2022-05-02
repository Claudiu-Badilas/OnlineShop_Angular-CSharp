namespace Server.Services.Interfaces {
    public interface ICategoryService {
        Task<bool> ExistsCategory(int id);
    }
}
