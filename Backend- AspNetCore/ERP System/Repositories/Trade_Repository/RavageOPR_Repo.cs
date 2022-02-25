using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class RavageOPR_Repo : IApplicationRepository<RavageOPR>
    {
        Application_Identity_DbContext DbContext;
        public RavageOPR_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(RavageOPR entity)
        {
            DbContext.Trade_RavageOPR.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            DbContext.Trade_RavageOPR.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(RavageOPR entity)
        {
            var RavageOPR = GetByID(entity.Id);
            if (RavageOPR != null)
            {
                RavageOPR.Date = entity.Date;
                RavageOPR.Notes = entity.Notes;
                DbContext.SaveChanges();
            }
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
