using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories.Interfaces;

namespace Server.Controllers {

    [Route("api/products")]
    public class ProductController : BaseController {

        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo) {
            _productRepo = productRepo;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProducts() {
            var products = await _productRepo.GetProducts();

            if (products.Count() == 0) return NoContent();

            return Ok(products);
        }
    }
}