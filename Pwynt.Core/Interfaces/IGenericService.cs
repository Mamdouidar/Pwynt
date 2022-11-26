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

        Task<T> GetByIdAsync(int id);

        Task<T> Find(Expression<Func<T, bool>> criteria);

        Task<T> AddAsync(T entity);

        void DeleteAsync(T entity);

        void Save();
    }
}
