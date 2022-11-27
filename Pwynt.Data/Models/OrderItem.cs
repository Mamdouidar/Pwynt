using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal TotalAmount { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
