using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemSpec_Restrict_Value_Repo : IApplicationRepository<ItemCategorySpec_Restrict_Item_Value>
    {
        Application_Identity_DbContext Db_Context;
        public ItemSpec_Restrict_Value_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public void Add(ItemCategorySpec_Restrict_Item_Value entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemCategorySpec_Restrict_Item_Value entity)
        {
            throw new NotImplementedException();
        }

        public ItemCategorySpec_Restrict_Item_Value GetByID(int id)
        {
            throw new NotImplementedException();
        }

        
        public List<ItemCategorySpec_Restrict_Item_Value> Get_ItemValuesList_For_SpecRestrict(Item Item_, ItemCategorySpec_Restrict ItemSpec_Restrict_)
        {
            return new List<ItemCategorySpec_Restrict_Item_Value>();
        }

        public IList<ItemCategorySpec_Restrict_Item_Value> List()
        {
            throw new NotImplementedException();
        }
    }
}
