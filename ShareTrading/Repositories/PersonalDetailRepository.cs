using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Entities;
using ShareTradingModel;

namespace Repositories
{
    public class PersonalDetailRepository: IEntityRepository<PersonalDetail>
    {
        private readonly ShareTradingEntities dbContext;
        public PersonalDetailRepository(IUnitOfWork unitOfWork)
        {
            dbContext =(ShareTradingEntities) unitOfWork.Context;
        }

        public IQueryable<PersonalDetail> All
        {
            get { return dbContext.PersonalDetails; }
        }

        public PersonalDetail FindById(int id)
        {
            return dbContext.PersonalDetails.FirstOrDefault(personalDetail => personalDetail.Id == id);
        }

        public void InsertOrUpdate(PersonalDetail sender)
        {
            dbContext.PersonalDetails.Add(sender);
        }

        public void DeleteById(int id)
        {
            PersonalDetail personalDetail = FindById(id);
            dbContext.PersonalDetails.Remove(personalDetail);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
