using ERP_System.Models.Materials;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemCategorySpec_Options_Repo : IApplicationRepository<ItemCategorySpec_Options>
    {
        private readonly Application_Identity_DbContext Db_Context;
        public ItemCategorySpec_Options_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public ItemCategorySpec_Options Add(ItemCategorySpec_Options entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemCategorySpec_Options entity)
        {
            throw new NotImplementedException();
        }

        public ItemCategorySpec_Options GetByID(int id)
        {
            throw new NotImplementedException();
        }


        //public List<ItemCategorySpec_Options> GetItemSpec_Restrict_Options_List(ItemCategorySpec ItemSpec_Restrict_)
        //{
        //    return new List<ItemCategorySpec_Restrict_Options>();
        //}

        public IList<ItemCategorySpec_Options> List()
        {
            throw new NotImplementedException();
        }
    }
}
