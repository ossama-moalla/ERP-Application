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
            DbContext.Accounting_MoneyAccount.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var moneyaccount = GetByID(id);
            DbContext.Accounting_MoneyAccount.Remove(moneyaccount);
            DbContext.SaveChanges();
        }

        public void Update(MoneyAccount entity)
        {
            var moneyaccount = GetByID(entity.Id);
            if (moneyaccount != null)
            {
                moneyaccount.Name = entity.Name;
                DbContext.SaveChanges();
            }
        }

        public MoneyAccount GetByID(int id)
        {
            return DbContext.Accounting_MoneyAccount.SingleOrDefault(x => x.Id == id);
        }
        
        public IList<MoneyAccount> List()
        {
            return DbContext.Accounting_MoneyAccount.ToList();
        }
    }
}
