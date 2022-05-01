using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Server.Controllers {
    [Route("api/categories")]
    public class CategoryController : BaseController {

        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo) {
            _categoryRepo = categoryRepo;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProducts() {
            var categories = await _categoryRepo.GetCategories();

            if (categories.Count() == 0) return NoContent();

            return Ok(categories);
        }
    }
}
