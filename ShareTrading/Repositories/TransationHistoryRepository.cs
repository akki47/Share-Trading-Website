using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Entities;
using ShareTradingModel;

namespace Repositories
{
    public class TransationHistoryRepository: IEntityRepository<TransactionHistory>
    {
        private readonly ShareTradingEntities dbContext;
        public TransationHistoryRepository(IUnitOfWork unitOfWork)
        {
            dbContext =(ShareTradingEntities) unitOfWork.Context;
        }

        public IQueryable<TransactionHistory> All
        {
            get { return dbContext.TransactionHistories; }
        }

        public TransactionHistory FindById(int id)
        {
            return dbContext.TransactionHistories.FirstOrDefault(transactionHistory => transactionHistory.Id == id);
        }

        public void InsertOrUpdate(TransactionHistory sender)
        {
            dbContext.TransactionHistories.Add(sender);
        }

        public void DeleteById(int id)
        {
            TransactionHistory transactionHistory = FindById(id);
            dbContext.TransactionHistories.Remove(transactionHistory);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
