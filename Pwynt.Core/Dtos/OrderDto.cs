using Pwynt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Core.Dtos
{
    public class OrderDto
    {
        public DateTime OrderDate { get; set; }
        public decimal FinalPrice { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
