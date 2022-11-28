using MediatR;
using Pwynt.Core.Interfaces;
using Pwynt.Core.Queries.CustomerQueries;
using Pwynt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Core.Handlers.CustomerHandlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdWithIncludesAsync(c => c.Id == request.Id, new[] { "Orders" });

            return customer;
        }
    }
}
