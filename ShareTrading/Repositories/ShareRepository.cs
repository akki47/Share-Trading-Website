using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Entities;
using ShareTradingModel;

namespace Repositories
{
    public class ShareRepository: IEntityRepository<Share>
    {
        private readonly ShareTradingEntities dbContext;
        public ShareRepository(IUnitOfWork unitOfWork)
        {
            dbContext =(ShareTradingEntities) unitOfWork.Context;
        }

        public IQueryable<Share> All
        {
            get { return dbContext.Shares; }
        }

        public Share FindById(int id)
        {
            return dbContext.Shares.FirstOrDefault(share => share.Id == id);
        }

        public void InsertOrUpdate(Share sender)
        {
            dbContext.Shares.Add(sender);
        }

        public void DeleteById(int id)
        {
            Share share = FindById(id);
            dbContext.Shares.Remove(share);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
