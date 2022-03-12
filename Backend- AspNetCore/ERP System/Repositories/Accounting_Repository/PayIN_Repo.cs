using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class PayIN_Repo : IApplicationRepository<PayIN>
    {
        private readonly Application_Identity_DbContext DbContext;
        public PayIN_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
       public PayIN Add(PayIN entity)
        {
            if (entity.CurrencyId == -1) entity.CurrencyId = null;
            DbContext.Accounting_PayIN.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var payin = DbContext.Accounting_PayIN.SingleOrDefault(x => x.Id == id);
            if (payin == null) LocalException.ThrowNotFound("Delete Failed! PayIN with Id:" + id + " Not Exists");
            DbContext.Accounting_PayIN.Remove(payin);
            DbContext.SaveChanges();
            
        }

        public void Update(PayIN entity)
        {
            var payin = DbContext.Accounting_PayIN.SingleOrDefault(x => x.Id == entity.Id);
            if (payin == null) LocalException.ThrowNotFound("Update Failed! PayIN with Id:" + entity.Id + " Not Exists");
            if (payin.CurrencyId == null) payin.Currency = null;
            //payin.MoneyAccountId = entity.MoneyAccountId;
            payin.CurrencyId = entity.CurrencyId == -1 ? null : entity.CurrencyId;
            payin.ExchangeRate = entity.ExchangeRate;
            payin.Value = entity.Value;
            payin.Description = entity.Description;
            payin.Notes = entity.Notes;
            DbContext.SaveChanges();
            
        }

        public PayIN GetByID(int id)
        { 
            var payin= DbContext.Accounting_PayIN.Include(y=>y.Currency).Include(y => y.MoneyAccount).SingleOrDefault(x => x.Id == id);
            if (payin == null) return null;
            DbContext.Entry(payin).State = EntityState.Detached;
            if ( payin.Currency == null)
            {
                payin.CurrencyId = -1;
                payin.Currency = Currency.ReferenceCurrency;
            }
            return payin;
        }
        public IList<PayIN> List()
        {
            var list = DbContext.Accounting_PayIN.Include(y => y.Currency).Include(y=>y.MoneyAccount).ToList();
            foreach(var payin in list)
            {
                DbContext.Entry(payin).State = EntityState.Detached;
                if (payin.Currency == null)
                {
                    payin.CurrencyId = -1;
                    payin.Currency = Currency.ReferenceCurrency;
                }
            }

            return list;
        }
    }
}
