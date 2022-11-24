using Pwynt.Core.Interfaces;
using Pwynt.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Core.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly PwyntDbContext _context;

        public GenericService(PwyntDbContext context)
        {
            _context = context;
        }
    }
}
