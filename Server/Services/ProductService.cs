using Server.Repositories.Interfaces;
using Server.Services.Interfaces;

namespace Server.Services {
    public class ProductService : IProductService {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        public async Task<bool> ExistsProduct(int productId) {

            var products = await _productRepository.GetProducts();
            return products.ToList().Exists(p => p.Id == productId);
        }
    }
}
