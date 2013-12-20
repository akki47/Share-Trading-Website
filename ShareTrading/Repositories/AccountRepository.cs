using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Entities;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using ShareTradingModel;

namespace Repositories
{
    public class AccountRepository : DbContext, IEntityRepository<Account>
    {
        private readonly ShareTradingEntities dbContext;
        public AccountRepository(IUnitOfWork unitOfWork)
        {
            dbContext = (ShareTradingEntities)unitOfWork.Context;
        }

        public IQueryable<Account> All
        {
            get { return dbContext.Accounts; }
        }

        public Account FindById(int id)
        {
            return dbContext.Accounts.FirstOrDefault(account => account.Id == id);
        }

        public void InsertOrUpdate(Account sender)
        {
            dbContext.Accounts.Add(sender);
        }

        public void DeleteById(int id)
        {
            Account account = FindById(id);
            dbContext.Accounts.Remove(account);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Account>().Property(p => p.Password).HasMaxLength(10);
            //SOme validation logic need to be written
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
