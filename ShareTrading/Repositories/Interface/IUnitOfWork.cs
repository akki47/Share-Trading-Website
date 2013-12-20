using System;
using System.Data.Entity;

namespace Repositories
{

    public interface IUnitOfWork : IDisposable
    {
        int Save();
        DbContext Context
        { get; }
    }
}
