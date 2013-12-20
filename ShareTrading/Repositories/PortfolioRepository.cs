using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Entities;
using ShareTradingModel;

namespace Repositories
{
    public class PortfolioRepository: IEntityRepository<Portfolio>
    {
        private readonly ShareTradingEntities dbContext;
        public PortfolioRepository(IUnitOfWork unitOfWork)
        {
            dbContext =(ShareTradingEntities) unitOfWork.Context;
        }

        public IQueryable<Portfolio> All
        {
            get { return dbContext.Portfolios; }
        }

        public Portfolio FindById(int id)
        {
            return dbContext.Portfolios.FirstOrDefault(portfolio => portfolio.Id == id);
        }

        public void InsertOrUpdate(Portfolio sender)
        {
            dbContext.Portfolios.Add(sender);
        }

        public void DeleteById(int id)
        {
            Portfolio portfolio = FindById(id);
            dbContext.Portfolios.Remove(portfolio);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
