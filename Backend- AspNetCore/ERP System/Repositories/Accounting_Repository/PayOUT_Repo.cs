using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class PayOUT_Repo : IApplicationRepository<PayOUT>
    {
        Application_Identity_DbContext DbContext;
        public PayOUT_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(PayOUT entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PayOUT entity)
        {
            throw new NotImplementedException();
        }

        public PayOUT GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<PayOUT> List()
        {
            throw new NotImplementedException();
        }

        internal List<PayOUT> GetPaysOUT_List(Operation Operation_)
        {
            throw new NotImplementedException();
        }
        internal List<PayOUT> Get_All_PaysOUT_List(MoneyAccount moneyAccount )
        {
            throw new NotImplementedException();
        }
    }
}
