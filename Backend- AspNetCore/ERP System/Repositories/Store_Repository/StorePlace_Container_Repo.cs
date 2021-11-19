using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Store_Repository
{
    public class StorePlace_Container_Repo : IApplicationRepository<StorePlace_Container>
    {
        Application_Identity_DbContext DbContext;
        public StorePlace_Container_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public void Add(StorePlace_Container entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(StorePlace_Container entity)
        {
            throw new NotImplementedException();
        }

        public StorePlace_Container GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public string GetContainerPath(StorePlace_Container container)
        {
            throw new NotImplementedException();
        }
        public StorePlace_Container GetParentContainer(StorePlace_Container container)
        {
            throw new NotImplementedException();
        }
        public List<StorePlace_Container> GetContainerChildsList(StorePlace_Container container)
        {
            throw new NotImplementedException();
        }

        public IList<StorePlace_Container> List()
        {
            throw new NotImplementedException();
        }
    }
}
