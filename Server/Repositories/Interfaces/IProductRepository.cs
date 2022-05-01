using Server.Models;

namespace Server.Repositories.Interfaces {
    public interface IProductRepository {
        public Task<IEnumerable<Product>> GetProducts();
    }
}
