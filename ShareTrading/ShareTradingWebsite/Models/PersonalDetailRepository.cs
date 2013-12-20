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
    public class PersonalDetailRepository : IPersonalDetailRepository
    {
        ShareTradingEntities context = new ShareTradingEntities();

        public IQueryable<PersonalDetail> All
        {
            get { return context.PersonalDetails; }
        }

        public IQueryable<PersonalDetail> AllIncluding(params Expression<Func<PersonalDetail, object>>[] includeProperties)
        {
            IQueryable<PersonalDetail> query = context.PersonalDetails;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public PersonalDetail Find(long id)
        {
            return context.PersonalDetails.Find(id);
        }

        public void InsertOrUpdate(PersonalDetail personaldetail)
        {
            if (personaldetail.Id == default(long)) {
                // New entity
                context.PersonalDetails.Add(personaldetail);
            } else {
                // Existing entity
                context.Entry(personaldetail).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var personaldetail = context.PersonalDetails.Find(id);
            context.PersonalDetails.Remove(personaldetail);
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

    public interface IPersonalDetailRepository : IDisposable
    {
        IQueryable<PersonalDetail> All { get; }
        IQueryable<PersonalDetail> AllIncluding(params Expression<Func<PersonalDetail, object>>[] includeProperties);
        PersonalDetail Find(long id);
        void InsertOrUpdate(PersonalDetail personaldetail);
        void Delete(long id);
        void Save();
    }
}