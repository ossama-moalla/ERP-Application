using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemCategorySpec_Restrict_Repo : IApplicationRepository<ItemCategorySpec_Restrict>
    {
        Application_Identity_DbContext Db_Context;
        public ItemCategorySpec_Restrict_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public void Add(ItemCategorySpec_Restrict entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemCategorySpec_Restrict entity)
        {
            throw new NotImplementedException();
        }

        public ItemCategorySpec_Restrict GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ItemCategorySpec_Restrict> List()
        {
            throw new NotImplementedException();
        }
        public List<ItemCategorySpec_Restrict> GetItemSpecRestrictList(ItemCategory ItemCategory_)
        {
            return new List<ItemCategorySpec_Restrict>();
        }

    }
}
