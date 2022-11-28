using MediatR;
using Pwynt.Core.Interfaces;
using Pwynt.Core.Queries.OrderQueries;
using Pwynt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Core.Handlers.OrderHandlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetByIdWithIncludesAsync(o => o.Id == request.Id, new[] { "OrderItems", "OrderItems.Product", "OrderItems.Product.Category" });

            return order;
        }
    }
}
