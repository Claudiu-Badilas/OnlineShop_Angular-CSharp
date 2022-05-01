using Server.Repositories.Models;

namespace Server.Repositories.Interfaces {
    public interface ICategoryRepository {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> AddCategory(string name);
        Task<Category> UpdateCategory(int categoryId, string name);
        void DeleteCategory(int categoryId);
    }
}
