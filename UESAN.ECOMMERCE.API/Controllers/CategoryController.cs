using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UESAN.ECOMMERCE.CORE.Core.Entities;
using UESAN.ECOMMERCE.CORE.Core.Interfaces;

namespace UESAN.ECOMMERCE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            var result = await _categoryRepository.CreateCategory(category);
            if (!result) return BadRequest();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category, int id)
        {
            if (id != category.Id)
                return BadRequest();

            var existingCategory = await _categoryRepository.GetCategoryById(id);
            if (existingCategory == null) return NotFound();

            var result = await _categoryRepository.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var existingCategory = await _categoryRepository.GetCategoryById(id);
            if (existingCategory == null) return NotFound();
            var result = await _categoryRepository.DeleteCategory(id);
            return NoContent();
        }


    }
}
