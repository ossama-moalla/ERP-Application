using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class Dealer_Repo : IApplicationRepository<Dealer>
    {
        Application_Identity_DbContext DbContext;
        public Dealer_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public void Add(Dealer entity)
        {
            DbContext.Trade_Dealer.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            DbContext.Trade_Dealer.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(Dealer entity)
        {
            var Dealer = GetByID(entity.Id);
            if (Dealer != null)
            {
                Dealer.Name = entity.Name;
                Dealer.DealerType = entity.DealerType;
                Dealer.Phone = entity.Phone;
                Dealer.Mobile = entity.Mobile;
                Dealer.Address = entity.Address;
                DbContext.SaveChanges();
            }
        }

        public Dealer GetByID(int id)
        {
            return DbContext.Trade_Dealer.SingleOrDefault(x => x.Id == id);
        }

        public IList<Dealer> List()
        {
            return DbContext.Trade_Dealer.ToList();
        }
    }
}
