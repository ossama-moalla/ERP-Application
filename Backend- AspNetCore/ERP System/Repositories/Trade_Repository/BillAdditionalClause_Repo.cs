using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class BillAdditionalClause_Repo:IApplicationRepository<BillAdditionalClause>
    {
        Application_Identity_DbContext DbContext;
        public BillAdditionalClause_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public void Add(BillAdditionalClause entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(BillAdditionalClause entity)
        {
            throw new NotImplementedException();
        }

        public BillAdditionalClause GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public List<BillAdditionalClause> GetBill_AdditionalClauses(Operation Operation_)
        {
            throw new NotImplementedException();
        }
        internal IEnumerable<Money_Currency> GetBill_AdditionalClauses_AS_Money_Currency(Currency _Currency, double exchangeRate, Operation _Operation)
        {
            throw new NotImplementedException();
        }
    }
}
