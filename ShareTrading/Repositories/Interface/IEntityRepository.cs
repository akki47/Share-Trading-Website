using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IEntityRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        T FindById(int id);
        void InsertOrUpdate(T sender);
        void DeleteById(int id);
    }
}
