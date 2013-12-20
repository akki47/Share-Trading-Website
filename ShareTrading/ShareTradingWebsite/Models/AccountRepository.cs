using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
//using Entities;
using ShareTradingModel;

namespace ShareTradingWebsite.Models
{ 
    public class AccountRepository : IAccountRepository
    {
        ShareTradingEntities context = new ShareTradingEntities();

        public IQueryable<Account> All
        {
            get { return context.Accounts; }
        }

        public IQueryable<Account> AllIncluding(params Expression<Func<Account, object>>[] includeProperties)
        {
            IQueryable<Account> query = context.Accounts;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Account Find(long id)
        {
            return context.Accounts.Find(id);
        }

        public void InsertOrUpdate(Account Account)
        {
            if (Account.Id == default(long)) {
                // New entity
                context.Accounts.Add(Account);
            } else {
                // Existing entity
                context.Entry(Account).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var Account = context.Accounts.Find(id);
            context.Accounts.Remove(Account);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IAccountRepository : IDisposable
    {
        IQueryable<Account> All { get; }
        IQueryable<Account> AllIncluding(params Expression<Func<Account, object>>[] includeProperties);
        Account Find(long id);
        void InsertOrUpdate(Account Account);
        void Delete(long id);
        void Save();
    }
}