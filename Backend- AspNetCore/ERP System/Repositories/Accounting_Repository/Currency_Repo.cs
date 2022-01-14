using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class Currency_Repo : IApplicationRepository<Currency>
    {
        Application_Identity_DbContext DbContext;
        public Currency_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(Currency entity)
        {
            DbContext.Accounting_Currency.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            DbContext.Accounting_Currency.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(Currency entity)
        {
            var currency = GetByID(entity.Id);
            if (currency != null)
            {
                currency.Name = entity.Name;
                currency.Symbol = entity.Symbol;
                currency.ExchangeRate = entity.ExchangeRate;
                currency.Disable = entity.Disable;
                DbContext.SaveChanges();
            }
        }

        public Currency GetByID(int id)
        {
            return DbContext.Accounting_Currency.SingleOrDefault(x => x.Id == id);
        }

        public IList<Currency> List()
        {
            return DbContext.Accounting_Currency.ToList();
        }


    }
}
