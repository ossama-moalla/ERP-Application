using ERP_System.Models.Trade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class RavageOPR_Repo : IApplicationRepository<RavageOPR>
    {
        private readonly Application_Identity_DbContext DbContext;
        public RavageOPR_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public RavageOPR Add(RavageOPR entity)
        {
            DbContext.Trade_RavageOPR.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            if(entity==null) LocalException.ThrowNotFound("Update Failed! RavageOPR with Id:" + entity.Id + " Not Exists");
            DbContext.Trade_RavageOPR.Remove(entity);
            DbContext.SaveChanges();
            
        }

        public void Update(RavageOPR entity)
        {
            var RavageOPR = GetByID(entity.Id);
            if (RavageOPR == null) LocalException.ThrowNotFound("Update Failed! RavageOPR with Id:" + entity.Id + " Not Exists");
            RavageOPR.Date = entity.Date;
            RavageOPR.Notes = entity.Notes;
            DbContext.SaveChanges();
            
        }

        public RavageOPR GetByID(int id)
        {
            return DbContext.Trade_RavageOPR.SingleOrDefault(x => x.Id == id);
        }

        public IList<RavageOPR> List()
        {
            return DbContext.Trade_RavageOPR.ToList();
        }
    }
}
