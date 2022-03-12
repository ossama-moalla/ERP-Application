using ERP_System.Models.Accounting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class MoneyTransFormOPR_Repo : IApplicationRepository<MoneyTransFormOPR>
    {
        private readonly Application_Identity_DbContext DbContext;
        public MoneyTransFormOPR_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public MoneyTransFormOPR Add(MoneyTransFormOPR entity)
        {
            if (entity.CurrencyId == -1) entity.CurrencyId = null;
            DbContext.Accounting_MoneyTransFormOPR.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var moneyTransformOpr = DbContext.Accounting_MoneyTransFormOPR.SingleOrDefault(x => x.Id == id);
            if (moneyTransformOpr == null) LocalException.ThrowNotFound("Delete Failed! MoneyTransform with Id:" + id + " Not Exists");
            DbContext.Accounting_MoneyTransFormOPR.Remove(moneyTransformOpr);
            DbContext.SaveChanges();
            
        }

        public void Update(MoneyTransFormOPR entity)
        {
            var moneyTransformOpr = DbContext.Accounting_MoneyTransFormOPR.SingleOrDefault(x => x.Id == entity.Id);
            if (moneyTransformOpr == null) LocalException.ThrowNotFound("Update Failed! MoneyTransform with Id:" + entity.Id + " Not Exists");
            moneyTransformOpr.SourceMoneyAccountId = entity.SourceMoneyAccountId;
            moneyTransformOpr.TargetMoneyAccountId = entity.TargetMoneyAccountId;
            moneyTransformOpr.CurrencyId = entity.CurrencyId == -1 ? null : entity.CurrencyId;
            moneyTransformOpr.ExchangeRate = entity.ExchangeRate;
            moneyTransformOpr.Value = entity.Value;
            moneyTransformOpr.Notes = entity.Notes;
            DbContext.SaveChanges();
            
        }

        public MoneyTransFormOPR GetByID(int id)
        {
            var moneytransformopr= DbContext.Accounting_MoneyTransFormOPR
                .Include(x=>x.SourceMoneyAccount)
                .Include(x => x.TargetMoneyAccount)
                .Include(x => x.Currency)
                .SingleOrDefault(x => x.Id == id);
            if (moneytransformopr == null) return null;
            DbContext.Entry(moneytransformopr).State = EntityState.Detached;
            if (moneytransformopr.Currency == null)
            {
                moneytransformopr.CurrencyId = -1;
                moneytransformopr.Currency = Currency.ReferenceCurrency;
            }
            return moneytransformopr;

        }
        public IList<MoneyTransFormOPR> List()
        {
            var list= DbContext.Accounting_MoneyTransFormOPR
                .Include(x => x.SourceMoneyAccount)
                .Include(x => x.TargetMoneyAccount)
                .Include(x => x.Currency).ToList();
            foreach (var moneytransformopr in list)
            {
                DbContext.Entry(moneytransformopr).State = EntityState.Detached;
                if (moneytransformopr.Currency == null)
                {
                    moneytransformopr.CurrencyId = -1;
                    moneytransformopr.Currency = Currency.ReferenceCurrency;
                }
            }
            return list;
        }
    }
}
