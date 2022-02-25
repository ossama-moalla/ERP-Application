using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class PurchasesBill_Repo : IApplicationRepository<PurchasesBill>
    {
        Application_Identity_DbContext DbContext;
        public PurchasesBill_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(PurchasesBill entity)
        {
            DbContext.Trade_PurchasesBill.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            DbContext.Trade_PurchasesBill.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(PurchasesBill entity)
        {
            var PurchasesBill = DbContext.Trade_PurchasesBill.SingleOrDefault(x => x.Id == entity.Id);
            if (PurchasesBill != null)
            {
                PurchasesBill.Date = entity.Date;
                PurchasesBill.Description = entity.Description;
                PurchasesBill.DealerId = entity.DealerId;
                PurchasesBill.CurrencyId = entity.CurrencyId;
                PurchasesBill.ExchangeRate = entity.ExchangeRate;
                PurchasesBill.Discount = entity.Discount;
                PurchasesBill.Notes = entity.Notes;
                DbContext.SaveChanges();
            }
        }

        public PurchasesBill GetByID(int id)
        {
            var PurchasesBill = DbContext.Trade_PurchasesBill.SingleOrDefault(x => x.Id == id);
            DbContext.Entry(PurchasesBill).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            if (PurchasesBill == null) return null;
            if (PurchasesBill.Currency == null) PurchasesBill.Currency = Currency.ReferenceCurrency;
            return PurchasesBill;
        }

        public IList<PurchasesBill> List()
        {
            var list= DbContext.Trade_PurchasesBill.ToList();
            foreach(var PurchasesBill in list)
            {
                DbContext.Entry(PurchasesBill).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                if (PurchasesBill.Currency == null) PurchasesBill.Currency = Currency.ReferenceCurrency;
            }
            return list;
        }
    }
}
