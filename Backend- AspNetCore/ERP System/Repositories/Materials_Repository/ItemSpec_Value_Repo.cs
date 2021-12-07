using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemSpec_Value_Repo 
    {
        Application_Identity_DbContext Db_Context;
        public ItemSpec_Value_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public void SetItemValue(Item Item_, ItemCategorySpec ItemSpec_, string value)
        {
            throw new NotImplementedException();
        }

        public void UNSetItemValueRestrict(Item Item_, ItemCategorySpec ItemSpec_)
        {
            throw new NotImplementedException();
        }

        public ItemCategorySpec_Item_Value GetItemSpec_Value(Item item, ItemCategorySpec ItemSpec_)
        {
            throw new NotImplementedException();
        }

    }
}
