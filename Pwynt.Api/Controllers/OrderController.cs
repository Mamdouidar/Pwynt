using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pwynt.Core.Dtos;
using Pwynt.Core.Interfaces;
using Pwynt.Data.Models;

namespace Pwynt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _unitOfWork.Orders.GetAllWithIncludesAsync(new[] { "OrderItems", "OrderItems.Product", "OrderItems.Product.Category" });

            if (orders == null)
                return NotFound();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdWithIncludesAsync(o => o.Id == id, new[] { "OrderItems", "OrderItems.Product", "OrderItems.Product.Category" });

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrderDto orderDto)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    OrderDate = orderDto.OrderDate,
                    FinalPrice = orderDto.FinalPrice,
                    CustomerId = orderDto.CustomerId,
                    OrderItems = (from item in orderDto.OrderItems select new OrderItem()
                    {
                        Quantity = item.Quantity,
                        ProductId = item.ProductId,
                        TotalAmount = item.TotalAmount
                    }).ToList()
                };

                await _unitOfWork.Orders.AddAsync(order);
                _unitOfWork.Complete();

                return Ok(order);
            }

            return BadRequest("Something went wrong, please try again.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);

            if (order == null)
                return NotFound();

            _unitOfWork.Orders.Delete(order);
            _unitOfWork.Complete();

            return Ok(order);
        }
    }
}
