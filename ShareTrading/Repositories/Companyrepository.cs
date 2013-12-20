using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Entities;
using ShareTradingModel;

namespace Repositories
{
    public class Companyrepository: IEntityRepository<Company>
    {
        private readonly ShareTradingEntities dbContext;
        public Companyrepository(IUnitOfWork unitOfWork)
        {
            dbContext =(ShareTradingEntities) unitOfWork.Context;
        }

        public IQueryable<Company> All
        {
            get { return dbContext.Companies; }
        }

        public Company FindById(int id)
        {
            return dbContext.Companies.FirstOrDefault(company => company.Id == id);
        }

        public void InsertOrUpdate(Company sender)
        {
            dbContext.Companies.Add(sender);
        }

        public void DeleteById(int id)
        {
            Company company = FindById(id);
            dbContext.Companies.Remove(company);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
