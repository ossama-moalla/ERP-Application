using ERP_System.Models.Accounting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class MoneyTransFormOPR_Repo : IApplicationRepository<MoneyTransFormOPR>
    {
        Application_Identity_DbContext DbContext;
        public MoneyTransFormOPR_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(MoneyTransFormOPR entity)
        {
            DbContext.Accounting_MoneyTransFormOPR.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var moneyTransformOpr = GetByID(id);
            DbContext.Accounting_MoneyTransFormOPR.Remove(moneyTransformOpr);
            DbContext.SaveChanges();
        }

        public void Update(MoneyTransFormOPR entity)
        {
            var moneyTransformOpr = GetByID(entity.Id);
            if (moneyTransformOpr != null)
            {
                moneyTransformOpr.SourceMoneyAccountId = entity.SourceMoneyAccountId;
                moneyTransformOpr.TargetMoneyAccountId = entity.TargetMoneyAccountId;
                moneyTransformOpr.CurrencyId = entity.CurrencyId; 
                moneyTransformOpr.ExchangeRate = entity.ExchangeRate;
                moneyTransformOpr.Value = entity.Value;
                moneyTransformOpr.Notes = entity.Notes;
                DbContext.SaveChanges();
            }
        }

        public MoneyTransFormOPR GetByID(int id)
        {
            return DbContext.Accounting_MoneyTransFormOPR
                .Include(x=>x.SourceMoneyAccount)
                .Include(x => x.TargetMoneyAccount)
                .Include(x => x.Currency)
                .SingleOrDefault(x => x.Id == id);
        }
        public IList<MoneyTransFormOPR> List()
        {
            return DbContext.Accounting_MoneyTransFormOPR
                .Include(x => x.SourceMoneyAccount)
                .Include(x => x.TargetMoneyAccount)
                .Include(x => x.Currency).ToList();
        }
    }
}
