using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Core.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAllWithIncludesAsync(string[] includes);

        Task<T> GetByIdAsync(int id);

        Task<T> GetByIdWithIncludesAsync(Expression<Func<T, bool>> criteria, string[] includes);

        Task<T> Find(Expression<Func<T, bool>> criteria);

        Task<T> AddAsync(T entity);

        void Delete(T entity);
    }
}
