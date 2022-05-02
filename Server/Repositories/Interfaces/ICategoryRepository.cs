using Server.Repositories.Models;

namespace Server.Repositories.Interfaces {
    public interface ICategoryRepository {
        Task<IEnumerable<Category>> GetCategories();
        Task AddCategory(string name);
        Task UpdateCategory(int categoryId, string name);
        void DeleteCategory(int categoryId);
    }
}
