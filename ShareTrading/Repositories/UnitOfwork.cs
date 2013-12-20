using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        public UnitOfWork()
        {
            context = new DbContext("connectionstring");
        }

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public int Save()
        {
            return this.context.SaveChanges();
        }

        public DbContext Context
        {
            get { return context; }
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

    }
}
