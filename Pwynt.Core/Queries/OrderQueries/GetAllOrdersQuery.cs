using MediatR;
using Pwynt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Core.Queries.OrderQueries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}
