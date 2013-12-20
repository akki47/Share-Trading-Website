using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    /// <summary>
    /// Generic Class for EntityRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityRepository<T>:IEntityRepository<T>
    {
        private readonly DbContext context;

        public EntityRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.Context;
        }

        public IQueryable<T> All
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<T> AllIncluding(params System.Linq.Expressions.Expression<Func<T, object>>[] includeingProperties)
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(T sender)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
