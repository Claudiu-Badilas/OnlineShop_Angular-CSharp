using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Server.Repositories.Models;

namespace Server.Controllers {
    [Route("api/categories")]
    public class CategoryController : BaseController {

        private readonly ICategoryRepository _categoryRepo;
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryRepository categoryRepo, ICategoryService categoryService) {
            _categoryRepo = categoryRepo;
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCategories() {
            var categories = await _categoryRepo.GetCategories();

            if (categories.Count() == 0) return NoContent();

            return Ok(categories);
        }

        [HttpPost("category")]
        public async Task<IActionResult> AddCategory([FromBody] Category category) {
            await _categoryRepo.AddCategory(category.Name);

            return Ok("The category has been saved successfully.");
        }

        [HttpPut("category")]
        public async Task<IActionResult> DeleteCategory([FromBody] Category category) {
            if (!await _categoryService.ExistsCategory(category.Id))
                return BadRequest("The category doesn't exists!");

            await _categoryRepo.UpdateCategory(category.Id, category.Name);
            return Ok("The category has been updated successfully.");
        }

        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id) {
            if (!await _categoryService.ExistsCategory(id))
                return BadRequest("The category doesn't exists!");

            _categoryRepo.DeleteCategory(id);
            return Ok("The category has been deleted successfully.");
        }
    }
}
