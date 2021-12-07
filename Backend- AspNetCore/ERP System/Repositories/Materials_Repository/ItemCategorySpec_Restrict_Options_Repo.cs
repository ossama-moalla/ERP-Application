using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemCategorySpec_Restrict_Options_Repo : IApplicationRepository<ItemCategorySpec_Restrict_Options>
    {
        Application_Identity_DbContext Db_Context;
        public ItemCategorySpec_Restrict_Options_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public void Add(ItemCategorySpec_Restrict_Options entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemCategorySpec_Restrict_Options entity)
        {
            throw new NotImplementedException();
        }

        public ItemCategorySpec_Restrict_Options GetByID(int id)
        {
            throw new NotImplementedException();
        }

        
        public List<ItemCategorySpec_Restrict_Options> GetItemSpec_Restrict_Options_List(ItemCategorySpec_Restrict ItemSpec_Restrict_)
        {
            return new List<ItemCategorySpec_Restrict_Options>();
        }

        public IList<ItemCategorySpec_Restrict_Options> List()
        {
            throw new NotImplementedException();
        }
    }
}
