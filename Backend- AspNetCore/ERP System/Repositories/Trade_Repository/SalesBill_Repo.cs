using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class SalesBill_Repo : IApplicationRepository<SalesBill>
    {
        Application_Identity_DbContext DbContext;
        public SalesBill_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public void Add(SalesBill entity)
        {
            DbContext.Trade_SalesBill.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            DbContext.Trade_SalesBill.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(SalesBill entity)
        {
            var SalesBill = DbContext.Trade_SalesBill.SingleOrDefault(x => x.Id == entity.Id);
            if (SalesBill != null)
            {
                SalesBill.Date = entity.Date;
                SalesBill.Description = entity.Description;
                SalesBill.DealerId = entity.DealerId;
                SalesBill.SellTypeId = entity.SellTypeId;
                SalesBill.CurrencyId = entity.CurrencyId;
                SalesBill.ExchangeRate = entity.ExchangeRate;
                SalesBill.Discount = entity.Discount;
                SalesBill.Notes = entity.Notes;
                DbContext.SaveChanges();
            }
        }

        public SalesBill GetByID(int id)
        {
            var SalesBill = DbContext.Trade_SalesBill.SingleOrDefault(x => x.Id == id);
            DbContext.Entry(SalesBill).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            if (SalesBill == null) return null;
            if (SalesBill.Currency == null) SalesBill.Currency = Currency.ReferenceCurrency;
            return SalesBill;
        }

        public IList<SalesBill> List()
        {
            var list = DbContext.Trade_SalesBill.ToList();
            foreach (var SalesBill in list)
            {
                DbContext.Entry(SalesBill).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                if (SalesBill.Currency == null) SalesBill.Currency = Currency.ReferenceCurrency;
            }
            return list;
        }
    }
}
