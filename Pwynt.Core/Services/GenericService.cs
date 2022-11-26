using Microsoft.EntityFrameworkCore;
using Pwynt.Core.Interfaces;
using Pwynt.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Find(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(criteria);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();

            return entity;
        }

        public void DeleteAsync(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
