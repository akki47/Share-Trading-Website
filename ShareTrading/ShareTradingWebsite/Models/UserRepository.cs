using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Entities;
using ShareTradingModel;

namespace ShareTradingWebsite.Models
{ 
    public class UserRepository : IUserRepository
    {
        ShareTradingEntities context = new ShareTradingEntities();

        public IQueryable<User> All
        {
            get { return context.Accounts.OfType<User>(); }
        }

        public IQueryable<User> AllIncluding(params Expression<Func<User, object>>[] includeProperties)
        {
            IQueryable<User> query = context.Accounts.OfType<User>();
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public User Find(long id)
        {
            return context.Set<User>().Find(id);
        }

        public void InsertOrUpdate(User user)
        {
            if (user.Id == default(long)) {
                // New entity
                context.Set<User>().Add(user);
            } else {
                // Existing entity
                context.Entry(user).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var user = context.Set<User>().Find(id);
            context.Set<User>().Remove(user);
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

    public interface IUserRepository : IDisposable
    {
        IQueryable<User> All { get; }
        IQueryable<User> AllIncluding(params Expression<Func<User, object>>[] includeProperties);
        User Find(long id);
        void InsertOrUpdate(User user);
        void Delete(long id);
        void Save();
    }
}