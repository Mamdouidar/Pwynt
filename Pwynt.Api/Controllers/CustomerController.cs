using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pwynt.Core.Dtos;
using Pwynt.Core.Interfaces;
using Pwynt.Core.Queries.CustomerQueries;
using Pwynt.Data.Models;

namespace Pwynt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CustomerController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCustomersQuery();
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetCustomerByIdQuery(id);
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var customer = await _unitOfWork.Customers.Find(c => c.FirstName == name);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Address= customerDto.Address,
                    Phone= customerDto.Phone,
                };

                await _unitOfWork.Customers.AddAsync(customer);
                _unitOfWork.Complete();

                return Ok(customer);
            }

            return BadRequest("Something went wrong, please try again.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CustomerDto customerDto)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.Address = customerDto.Address;
            customer.Phone = customerDto.Phone;
            _unitOfWork.Complete();

            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            _unitOfWork.Customers.Delete(customer);
            _unitOfWork.Complete();

            return Ok(customer);
        }
    }
}
