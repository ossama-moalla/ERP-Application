using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class ExchangeOPR_Repo : IApplicationRepository<ExchangeOPR>
    {
        Application_Identity_DbContext DbContext;
        public ExchangeOPR_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(ExchangeOPR entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ExchangeOPR entity)
        {
            throw new NotImplementedException();
        }

        public ExchangeOPR GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ExchangeOPR> List()
        {
            throw new NotImplementedException();
        }

        internal List<ExchangeOPR> Get_List(MoneyAccount moneyAccount)
        {
            throw new NotImplementedException();
        }
    }
}
