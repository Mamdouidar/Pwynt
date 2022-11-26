using Pwynt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericService<Category> Categories { get; }

        int Complete();
    }
}
