using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class TradeState_Repo:IApplicationRepository<TradeState>
    {
        Application_Identity_DbContext DbContext;
        public TradeState_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public void Add(TradeState entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(TradeState entity)
        {
            throw new NotImplementedException();
        }

        public TradeState GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public List<TradeState> GetTradeStateList()
        {
            throw new NotImplementedException();
        }
    }
}
