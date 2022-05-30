using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

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

            if (products.Count() == 0) return BadRequest();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id) {
            var product = await _productRepo.GetProductById(id);

            if (product == null) return BadRequest("The product doesn't exists!");

            return Ok(product);
        }

        [Authorize]
        [HttpPost("product")]
        public async Task<IActionResult> AddProduct([FromBody] Product product) {
            await _productRepo.AddProduct(product.Name, product.Description, product.Image, product.Price, product.Category.Id);

            return Ok("The product has been saved successfully.");
        }

        [Authorize]
        [HttpPut("product")]
        public async Task<IActionResult> DeleteProduct([FromBody] Product product) {
            if (!await _productService.ExistsProduct(product.Id))
                return BadRequest("The product doesn't exists!");

            await _productRepo.UpdateProduct(product.Id, product.Name, product.Description, product.Image, product.Price, product.Category.Id);
            return Ok("The product has been updated successfully.");
        }

        [Authorize]
        [HttpDelete("product/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id) {
            if (!await _productService.ExistsProduct(id))
                return BadRequest("The product doesn't exists!");

            _productRepo.DeleteProduct(id);
            return Ok("The product has been deleted successfully.");
        }
    }
}