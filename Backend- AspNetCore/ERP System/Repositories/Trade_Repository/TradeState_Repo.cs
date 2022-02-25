using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class TradeState_Repo : IApplicationRepository<TradeState>
    {
        Application_Identity_DbContext DbContext;
        public TradeState_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public void Add(TradeState entity)
        {
            DbContext.Trade_TradeState.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            DbContext.Trade_TradeState.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(TradeState entity)
        {
            var TradeState = GetByID(entity.Id);
            if (TradeState != null)
            {
                TradeState.Name = entity.Name;
                DbContext.SaveChanges();
            }
        }

        public TradeState GetByID(int id)
        {
            return DbContext.Trade_TradeState.SingleOrDefault(x => x.Id == id);
        }

        public IList<TradeState> List()
        {
            return DbContext.Trade_TradeState.ToList();
        }
    }
}
