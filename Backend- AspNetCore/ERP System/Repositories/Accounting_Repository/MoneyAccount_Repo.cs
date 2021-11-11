using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class MoneyAccount_Repo : IApplicationRepository<MoneyAccount>
    {
        Application_Identity_DbContext DbContext;
        public MoneyAccount_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(MoneyAccount entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(MoneyAccount entity)
        {
            throw new NotImplementedException();
        }

        public MoneyAccount GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public List<MoneyAccount> GetMoneyAccount_List()
        {
            throw new NotImplementedException();
        }
    }
}
