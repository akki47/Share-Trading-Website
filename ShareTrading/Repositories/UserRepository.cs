using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareTradingModel;

namespace Repositories
{
    public class UserRepository: IEntityRepository<User>
    {
        private readonly ShareTradingEntities dbContext;
        public UserRepository(IUnitOfWork unitOfWork)
        {
            dbContext =(ShareTradingEntities) unitOfWork.Context;
        }

        public IQueryable<User> All
        {
            get { return dbContext.Users; }
        }

        public User FindById(int id)
        {
            return dbContext.Users.FirstOrDefault(user => user.Id == id);
        }

        public void InsertOrUpdate(User sender)
        {
            dbContext.Users.Add(sender);
        }

        public void DeleteById(int id)
        {
            User user = FindById(id);
            dbContext.Users.Remove(user);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
