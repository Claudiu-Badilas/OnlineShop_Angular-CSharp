using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;

namespace Server.Controllers {

    [Route("api/products")]
    public class ProductController : BaseController {

        private readonly IProductRepository _productRepo;
        private readonly IProductService _productService;

        public ProductController(IProductRepository productRepo, IProductService productService) {
            _productRepo = productRepo;
            _productService = productService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProducts() {
            var products = await _productRepo.GetProducts();

            if (products.Count() == 0) return NoContent();

            return Ok(products);
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id) {
            if (!await _productService.ExistsProduct(id))
                return BadRequest("This product doesn't exists!");

            _productRepo.DeleteProduct(id);
            return Ok("Product was deleted successfully!");
        }
    }
}