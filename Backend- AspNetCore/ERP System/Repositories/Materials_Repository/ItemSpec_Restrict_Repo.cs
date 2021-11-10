using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemSpec_Restrict_Repo : IApplicationRepository<ItemSpec_Restrict>
    {
        Application_Identity_DbContext Db_Context;
        public ItemSpec_Restrict_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public void Add(ItemSpec_Restrict entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(ItemSpec_Restrict entity)
        {
            throw new NotImplementedException();
        }

        public ItemSpec_Restrict GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ItemSpec_Restrict> List()
        {
            throw new NotImplementedException();
        }
        public List<ItemSpec_Restrict> GetItemSpecRestrictList(ItemCategory ItemCategory_)
        {
            return new List<ItemSpec_Restrict>();
        }

    }
}
