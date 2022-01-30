using ERP_System.Models.Accounting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class ExchangeOPR_Repo : IApplicationRepository<ExchangeOPR>
    {
        Application_Identity_DbContext DbContext;
        public ExchangeOPR_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(ExchangeOPR entity)
        {
            if (entity.SourceCurrencyId == -1) entity.SourceCurrencyId = null;
            if (entity.TargetCurrencyId == -1) entity.TargetCurrencyId = null;
            DbContext.Accounting_ExchangeOPR.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var exchangeopr = GetByID(id);
            DbContext.Accounting_ExchangeOPR.Remove(exchangeopr);
            DbContext.SaveChanges();
        }

        public void Update(ExchangeOPR entity)
        {
            var exchangeopr = GetByID(entity.Id);
            if (exchangeopr != null)
            {
                exchangeopr.MoneyAccountId = entity.MoneyAccountId;
                exchangeopr.SourceCurrencyId = entity.SourceCurrencyId == -1 ? null : entity.SourceCurrencyId;
                exchangeopr.SourceExchangeRate = entity.SourceExchangeRate;
                exchangeopr.TargetCurrencyId = entity.TargetCurrencyId==-1?null:entity.TargetCurrencyId;
                exchangeopr.TargetExchangeRate = entity.TargetExchangeRate;
                exchangeopr.OutMoneyValue = entity.OutMoneyValue;
                exchangeopr.Notes = entity.Notes;
                DbContext.SaveChanges();
            }
        }

        public ExchangeOPR GetByID(int id)
        {
            var exchangeopr= DbContext.Accounting_ExchangeOPR
                .Include(x=>x.SourceCurrency)
                .Include(x => x.TargetCurrency)
                .Include(x => x.MoneyAccount)
                .SingleOrDefault(x => x.Id == id);
            if (exchangeopr != null)
            {
                if (exchangeopr.SourceCurrency == null) exchangeopr.SourceCurrency = Currency.ReferenceCurrency;
                if (exchangeopr.TargetCurrency == null) exchangeopr.TargetCurrency = Currency.ReferenceCurrency;
            }
            return exchangeopr;
        }
        public IList<ExchangeOPR> List()
        {
            var list= DbContext.Accounting_ExchangeOPR
                .Include(x => x.SourceCurrency)
                .Include(x => x.TargetCurrency)
                .Include(x => x.MoneyAccount).ToList();
            foreach (var exchangeopr in list)
            {
                if (exchangeopr.SourceCurrency == null) exchangeopr.SourceCurrency = Currency.ReferenceCurrency;
                if (exchangeopr.TargetCurrency == null) exchangeopr.TargetCurrency = Currency.ReferenceCurrency;

            }
            return list;
        }
    }
}
