using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class SellType_Repo : IApplicationRepository<SellType>
    {
        Application_Identity_DbContext DbContext;
        public SellType_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public void Add(SellType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SellType entity)
        {
            throw new NotImplementedException();
        }

        public SellType GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public List<SellType> GetSellTypeList()
        {
            throw new NotImplementedException();
        }

        public IList<SellType> List()
        {
            throw new NotImplementedException();
        }
    }
}
