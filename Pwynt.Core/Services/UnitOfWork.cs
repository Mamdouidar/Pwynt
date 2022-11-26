using Pwynt.Core.Interfaces;
using Pwynt.Data.Data;
using Pwynt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Core.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PwyntDbContext _context;

        public IGenericService<Category> Categories { get; private set; }
        public IGenericService<Product> Products { get; private set; }

        public UnitOfWork(PwyntDbContext context)
        {
            _context = context;

            Categories = new GenericService<Category>(_context);
            Products = new GenericService<Product>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
