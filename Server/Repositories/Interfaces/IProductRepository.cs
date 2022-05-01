using Server.Models;

namespace Server.Repositories.Interfaces {
    public interface IProductRepository {
        Task<IEnumerable<Product>> GetProducts();
        void DeleteProduct(int id);
    }
}
