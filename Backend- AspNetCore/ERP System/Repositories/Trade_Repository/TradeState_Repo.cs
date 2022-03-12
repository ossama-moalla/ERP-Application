using ERP_System.Models.Trade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class TradeState_Repo : IApplicationRepository<TradeState>
    {
        private readonly Application_Identity_DbContext DbContext;
        public TradeState_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public TradeState Add(TradeState entity)
        {
            DbContext.Trade_TradeState.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            if (entity == null) LocalException.ThrowNotFound("Delete Failed! TradeState with Id:" +id + " Not Exists");
            DbContext.Trade_TradeState.Remove(entity);
            DbContext.SaveChanges();
            
        }

        public void Update(TradeState entity)
        {
            var TradeState = GetByID(entity.Id);
            if (TradeState == null) LocalException.ThrowNotFound("Update Failed! TradeState with Id:" + entity.Id + " Not Exists");
            TradeState.Name = entity.Name;
            DbContext.SaveChanges();
            
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
