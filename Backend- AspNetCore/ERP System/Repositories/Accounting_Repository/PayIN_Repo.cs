using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class PayIN_Repo : IApplicationRepository<PayIN>
    {
        Application_Identity_DbContext DbContext;
        public PayIN_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(PayIN entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PayIN entity)
        {
            throw new NotImplementedException();
        }

        public PayIN GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<PayIN> List()
        {
            throw new NotImplementedException();
        }

        internal List<Money_Currency> GetPayINList_As_Money_Currency(Operation opeartion)
        {
            throw new NotImplementedException();

        }
        internal List<PayIN> Get_All_PayINList(MoneyAccount moneyAccount)
        {
            throw new NotImplementedException();
        }
    }
}
