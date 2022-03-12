using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class BillAdditionalClause_Repo:IApplicationRepository<BillAdditionalClause>
    {
        private readonly Application_Identity_DbContext DbContext;
        public BillAdditionalClause_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public BillAdditionalClause Add(BillAdditionalClause entity)
        {
            DbContext.Trade_BillAdditionalClause.Add(entity);
            DbContext.SaveChanges();
            return entity;


        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            if(entity==null) LocalException.ThrowNotFound("Delete Failed! AdditionalClause with Id:" + id + " Not Exists");
            DbContext.Trade_BillAdditionalClause.Remove(entity);
            DbContext.SaveChanges();
            
        }

        public void Update(BillAdditionalClause entity)
        {
            var BillAdditionalClause = GetByID(entity.Id);
            if (BillAdditionalClause == null) LocalException.ThrowNotFound("Update Failed! AdditionalClause with Id:" + entity.Id + " Not Exists");
            BillAdditionalClause.Description = entity.Description;
            BillAdditionalClause.Value = entity.Value;
            DbContext.SaveChanges();
             
        }

        public BillAdditionalClause GetByID(int id)
        {
            return DbContext.Trade_BillAdditionalClause.SingleOrDefault(x => x.Id == id);
        }

        public IList<BillAdditionalClause> List()
        {
            return DbContext.Trade_BillAdditionalClause.ToList();
        }
    }
}
