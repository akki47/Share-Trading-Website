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
    public class CompanyRepository : ICompanyRepository
    {
        ShareTradingEntities context = new ShareTradingEntities();

        public IQueryable<Company> All
        {
            get { return context.Companies; }
        }

        public IQueryable<Company> AllIncluding(params Expression<Func<Company, object>>[] includeProperties)
        {
            IQueryable<Company> query = context.Companies;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Company Find(long id)
        {
            return context.Companies.Find(id);
        }

        public void InsertOrUpdate(Company company)
        {
            if (company.Id == default(long)) {
                // New entity
                context.Companies.Add(company);
            } else {
                // Existing entity
                context.Entry(company).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var company = context.Companies.Find(id);
            context.Companies.Remove(company);
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

    public interface ICompanyRepository : IDisposable
    {
        IQueryable<Company> All { get; }
        IQueryable<Company> AllIncluding(params Expression<Func<Company, object>>[] includeProperties);
        Company Find(long id);
        void InsertOrUpdate(Company company);
        void Delete(long id);
        void Save();
    }
}