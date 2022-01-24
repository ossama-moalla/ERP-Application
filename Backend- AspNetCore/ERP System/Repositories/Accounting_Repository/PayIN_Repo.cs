using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class PayIN_Repo : IApplicationRepository<PayIN>
    {
        Application_Identity_DbContext DbContext;
        public PayIN_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
       public void Add(PayIN entity)
        {
            if (entity.CurrencyId == -1) entity.CurrencyId = null;
            DbContext.Accounting_PayIN.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var payin = GetByID(id);
            DbContext.Accounting_PayIN.Remove(payin);
            DbContext.SaveChanges();
        }

        public void Update(PayIN entity)
        {
            var payin = GetByID(entity.Id);
            if (payin != null)
            {
                payin.MoneyAccountId = entity.MoneyAccountId;
                payin.CurrencyId = entity.CurrencyId==-1?null:entity.CurrencyId;
                payin.ExchangeRate = entity.ExchangeRate;
                payin.Value = entity.Value;
                payin.Description = entity.Description;
                payin.Notes = entity.Notes;
                DbContext.SaveChanges();
            }
        }

        public PayIN GetByID(int id)
        {
            var payin= DbContext.Accounting_PayIN.Include(y=>y.Currency).Include(y => y.MoneyAccount).SingleOrDefault(x => x.Id == id);
            if (payin.Currency == null) payin.Currency = Currency.ReferenceCurrency;
            return payin;
        }
        public IList<PayIN> List()
        {
            var list = DbContext.Accounting_PayIN.Include(y => y.Currency).Include(y=>y.MoneyAccount).ToList();
            foreach(var payin in list)
            {
                if (payin.Currency == null) payin.Currency = Currency.ReferenceCurrency;
            }
            return list;
        }
    }
}
