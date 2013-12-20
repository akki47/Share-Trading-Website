using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
//using Entities;
using ExceptionHandlingFramework;
using ShareTradingModel;

namespace ShareTradingWebsite.Models
{ 
    public class ShareRepository : IShareRepository
    {
        ShareTradingEntities context = new ShareTradingEntities();

        public IQueryable<Share> All
        {
            get { return context.Shares; }
        }

        public IQueryable<Share> AllIncluding(params Expression<Func<Share, object>>[] includeProperties)
        {
            IQueryable<Share> query = context.Shares;
            foreach (var includeProperty in includeProperties)
            {
                query = ExceptionHandlingManager.Instance.Process(() => query.Include(includeProperty), ExceptionPolicy.ASSISTING_ADMINISTRATORS);
            }

            ExceptionPolicy policy = new ExceptionPolicy();
            return query;
        }

        public Share Find(long id)
        {
            return context.Shares.Find(id);
        }

        public void InsertOrUpdate(Share share)
        {
            if (share.Id == default(long)) {
                // New entity
                context.Shares.Add(share);
            } else {
                // Existing entity
                context.Entry(share).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var share = context.Shares.Find(id);
            context.Shares.Remove(share);
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

    public interface IShareRepository : IDisposable
    {
        IQueryable<Share> All { get; }
        IQueryable<Share> AllIncluding(params Expression<Func<Share, object>>[] includeProperties);
        Share Find(long id);
        void InsertOrUpdate(Share share);
        void Delete(long id);
        void Save();
    }
}