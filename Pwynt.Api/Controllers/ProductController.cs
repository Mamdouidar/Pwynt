using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pwynt.Core.Dtos;
using Pwynt.Core.Interfaces;
using Pwynt.Core.Queries.ProductQueries;
using Pwynt.Data.Models;

namespace Pwynt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public ProductController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : NotFound();

            //var products = await _unitOfWork.Products.GetAllWithIncludesAsync(new[] { "Category" });

            //if (products == null)
            //    return NotFound();

            //return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : NotFound();

            //var product = await _unitOfWork.Products.GetByIdWithIncludesAsync(p => p.Id == id, new[] { "Category" });

            //if (product == null)
            //    return NotFound();

            //return Ok(product);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var product = await _unitOfWork.Products.Find(c => c.Name == name);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryId= productDto.CategoryId,
                };

                await _unitOfWork.Products.AddAsync(product);
                _unitOfWork.Complete();

                return Ok(product);
            }

            return BadRequest("Something went wrong, please try again.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductDto productDto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.CategoryId = productDto.CategoryId;
            _unitOfWork.Complete();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            _unitOfWork.Products.Delete(product);
            _unitOfWork.Complete();

            return Ok(product);
        }
    }
}
