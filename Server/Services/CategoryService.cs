using Server.Repositories.Interfaces;
using Server.Services.Interfaces;

namespace Server.Services {
    public class CategoryService : ICategoryService {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo) {
            _categoryRepo = categoryRepo;
        }

        public async Task<bool> ExistsCategory(int categoryId) {
            var categories = await _categoryRepo.GetCategories();
            return categories.ToList().Exists(c => c.Id == categoryId);
        }
    }
}
