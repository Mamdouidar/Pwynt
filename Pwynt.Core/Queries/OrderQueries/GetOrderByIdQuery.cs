using MediatR;
using Pwynt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Core.Queries.OrderQueries
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int Id { get; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
