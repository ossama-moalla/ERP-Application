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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(RavageOPR entity)
        {
            throw new NotImplementedException();
        }

        public RavageOPR GetByID(int id)
        {
            throw new NotImplementedException();
        }
        internal List<RavageOPR> Get_All_RavageOPR_List()
        {
            throw new NotImplementedException();
        }
    }
}
