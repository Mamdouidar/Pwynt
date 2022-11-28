using MediatR;
using Pwynt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Core.Queries.CustomerQueries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; }

        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
