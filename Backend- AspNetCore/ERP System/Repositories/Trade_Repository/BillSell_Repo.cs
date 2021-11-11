using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class BillSell_Repo:IApplicationRepository<BillSell>
    {
        Application_Identity_DbContext DbContext;
        public BillSell_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public void Add(BillSell entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(BillSell entity)
        {
            throw new NotImplementedException();
        }

        public BillSell GetByID(int id)
        {
            throw new NotImplementedException();
        }
        internal double GetBillSellValue(uint billsellid)
        {
            throw new NotImplementedException();
        }
        internal double GetBillSell_PaysValue(uint billsellid)
        {
            throw new NotImplementedException();
        }
        internal List<BillSell> Get_All_BillSell_List()
        {
            throw new NotImplementedException();
        }
    }
}
