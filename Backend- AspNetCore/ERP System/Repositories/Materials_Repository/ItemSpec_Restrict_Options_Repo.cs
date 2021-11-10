using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemSpec_Restrict_Options_Repo : IApplicationRepository<ItemSpec_Restrict_Options>
    {
        Application_Identity_DbContext Db_Context;
        public ItemSpec_Restrict_Options_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public void Add(ItemSpec_Restrict_Options entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(ItemSpec_Restrict_Options entity)
        {
            throw new NotImplementedException();
        }

        public ItemSpec_Restrict_Options GetByID(int id)
        {
            throw new NotImplementedException();
        }

        
        public List<ItemSpec_Restrict_Options> GetItemSpec_Restrict_Options_List(ItemSpec_Restrict ItemSpec_Restrict_)
        {
            return new List<ItemSpec_Restrict_Options>();
        }
    }
}
