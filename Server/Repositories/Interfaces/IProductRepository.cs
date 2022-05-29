using Server.Models;

namespace Server.Repositories.Interfaces {
    public interface IProductRepository {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(string name, string description, string image, double price, int categoryId);
        Task UpdateProduct(int productId, string name, string description, string image, double price, int categoryId);
        void DeleteProduct(int id);
    }
}
