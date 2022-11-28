using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pwynt.Core.Dtos;
using Pwynt.Core.Interfaces;
using Pwynt.Core.Queries.OrderQueries;
using Pwynt.Data.Models;

namespace Pwynt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public OrderController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetOrderByIdQuery(id);
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : NotFound();
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
