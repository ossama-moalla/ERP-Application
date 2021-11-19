using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class Currency_Repo : IApplicationRepository<Currency>
    {
        Application_Identity_DbContext DbContext;
        public Currency_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(Currency entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Currency entity)
        {
            throw new NotImplementedException();
        }

        public Currency GetByID(int id)
        {
            throw new NotImplementedException();
        }
        internal Currency GetReferenceCurrency()
        {
            throw new NotImplementedException();

        }
        internal List<Currency> getList()
        {
            throw new NotImplementedException();

        }

        public IList<Currency> List()
        {
            throw new NotImplementedException();
        }
    }
}
