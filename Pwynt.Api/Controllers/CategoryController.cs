using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pwynt.Core.Dtos;
using Pwynt.Core.Interfaces;
using Pwynt.Data.Models;

namespace Pwynt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericService<Category> _categoryService;

        public CategoryController(IGenericService<Category> categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();

            if(categories == null)
                return NotFound();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if(category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var category = await _categoryService.Find(c => c.Name == name);

            if(category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryDto categoryDto)
        {
            if(ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = categoryDto.Name,
                };

                await _categoryService.AddAsync(category);
                
                return Ok(category);
            }

            return BadRequest("Something went wrong, please try again.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoryDto categoryDto)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if(category == null)
                return NotFound();

            category.Name = categoryDto.Name;
            _categoryService.Save();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if(category == null)
                return NotFound();

            _categoryService.DeleteAsync(category);

            return Ok(category);
        }

    }
}
