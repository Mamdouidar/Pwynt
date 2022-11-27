using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pwynt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Data.Data
{
    public class PwyntDbContext : IdentityDbContext<ApplicationUser>
    {
        public PwyntDbContext(DbContextOptions<PwyntDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
