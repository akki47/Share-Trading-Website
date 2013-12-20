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
    public class AddressRepository : IAddressRepository
    {
        ShareTradingEntities context = new ShareTradingEntities();

        public IQueryable<Address> All
        {
            get { return context.Addresses; }
        }

        public IQueryable<Address> AllIncluding(params Expression<Func<Address, object>>[] includeProperties)
        {
            IQueryable<Address> query = context.Addresses;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Address Find(long id)
        {
            return context.Addresses.Find(id);
        }

        public void InsertOrUpdate(Address address)
        {
            if (address.Id == default(long)) {
                // New entity
                context.Addresses.Add(address);
            } else {
                // Existing entity
                context.Entry(address).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var address = context.Addresses.Find(id);
            context.Addresses.Remove(address);
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

    public interface IAddressRepository : IDisposable
    {
        IQueryable<Address> All { get; }
        IQueryable<Address> AllIncluding(params Expression<Func<Address, object>>[] includeProperties);
        Address Find(long id);
        void InsertOrUpdate(Address address);
        void Delete(long id);
        void Save();
    }
}