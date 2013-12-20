using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Entities;
using ShareTradingModel;

namespace Repositories
{
    public class AddressRepository: IEntityRepository<Address>
    {
        private readonly ShareTradingEntities dbContext;
        public AddressRepository(IUnitOfWork unitOfWork)
        {
            dbContext =(ShareTradingEntities) unitOfWork.Context;
        }

        public IQueryable<Address> All
        {
            get { return dbContext.Addresses; }
        }

        public Address FindById(int id)
        {
            return dbContext.Addresses.FirstOrDefault(address => address.Id == id);
        }

        public void InsertOrUpdate(Address sender)
        {
            dbContext.Addresses.Add(sender);
        }

        public void DeleteById(int id)
        {
            Address address = FindById(id);
            dbContext.Addresses.Remove(address);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
