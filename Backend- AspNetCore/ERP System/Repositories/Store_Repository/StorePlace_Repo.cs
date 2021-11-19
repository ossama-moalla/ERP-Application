using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Store_Repository
{
    public class StorePlace_Repo : IApplicationRepository<StorePlace>
    {
        Application_Identity_DbContext DbContext;
        public StorePlace_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public void Add(StorePlace entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(StorePlace entity)
        {
            throw new NotImplementedException();
        }

        public StorePlace GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public string GetPlacePath(StorePlace place)
        {
            throw new NotImplementedException();
        }
        public List<StorePlace> GetPlacesINContainer(StorePlace_Container container)
        {
            throw new NotImplementedException();
        }

        public IList<StorePlace> List()
        {
            throw new NotImplementedException();
        }

        internal List<StorePlace> SearchPlace(string text)
        {
            throw new NotImplementedException();
        }
        internal List<StorePlace> SearchPlacesInContainer(StorePlace_Container _Container, string text)
        {
            throw new NotImplementedException();
        }
    }
}
