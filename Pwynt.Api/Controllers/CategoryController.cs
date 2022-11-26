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
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAll();

            if(categories == null)
                return NotFound();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if(category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var category = await _unitOfWork.Categories.Find(c => c.Name == name);

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

                await _unitOfWork.Categories.AddAsync(category);
                _unitOfWork.Complete();
                
                return Ok(category);
            }

            return BadRequest("Something went wrong, please try again.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoryDto categoryDto)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if(category == null)
                return NotFound();

            category.Name = categoryDto.Name;
            _unitOfWork.Complete();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if(category == null)
                return NotFound();

            _unitOfWork.Categories.Delete(category);
            _unitOfWork.Complete();

            return Ok(category);
        }

    }
}
