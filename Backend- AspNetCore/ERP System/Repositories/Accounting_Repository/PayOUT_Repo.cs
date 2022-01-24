using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class PayOUT_Repo : IApplicationRepository<PayOUT>
    {
        Application_Identity_DbContext DbContext;
        public PayOUT_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(PayOUT entity)
        {
            if (entity.CurrencyId == -1) entity.CurrencyId = null;
            DbContext.Accounting_PayOUT.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var payout = GetByID(id);
            DbContext.Accounting_PayOUT.Remove(payout);
            DbContext.SaveChanges();
        }

        public void Update(PayOUT entity)
        {
            var payout = GetByID(entity.Id);
            if (payout != null)
            {
                payout.MoneyAccountId = entity.MoneyAccountId;
                payout.CurrencyId = entity.CurrencyId == -1 ? null : entity.CurrencyId;
                payout.ExchangeRate = entity.ExchangeRate;
                payout.Value = entity.Value;
                payout.Description = entity.Description;
                payout.Notes = entity.Notes;
                DbContext.SaveChanges();
            }
        }

        public PayOUT GetByID(int id)
        {
            var payout= DbContext.Accounting_PayOUT.Include(y => y.Currency).Include(y => y.MoneyAccount).SingleOrDefault(x => x.Id == id);
            if (payout.Currency == null) payout.Currency = Currency.ReferenceCurrency;
            return payout;
        }
        public IList<PayOUT> List()
        {
            var list = DbContext.Accounting_PayOUT.Include(y => y.Currency).Include(y => y.MoneyAccount).ToList();
            foreach (var payout in list)
            {
                if (payout.Currency == null) payout.Currency = Currency.ReferenceCurrency;
            }
            return list;
        }
    }
}
