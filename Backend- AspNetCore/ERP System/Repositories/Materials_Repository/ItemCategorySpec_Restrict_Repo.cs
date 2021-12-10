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
            Db_Context.Materials_ItemCategorySpec_Restrict.Add(entity);
            Db_Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Db_Context.Materials_ItemCategorySpec_Restrict.Remove(GetByID(id));
            Db_Context.SaveChanges();
        }

        public void Update(ItemCategorySpec_Restrict entity)
        {
            Db_Context.Materials_ItemCategorySpec_Restrict.Update(entity);
            Db_Context.SaveChanges();
        }

        public ItemCategorySpec_Restrict GetByID(int id)
        {
            return Db_Context.Materials_ItemCategorySpec_Restrict.SingleOrDefault(x => x.id == id);
        }

        public IList<ItemCategorySpec_Restrict> List()
        {
            return Db_Context.Materials_ItemCategorySpec_Restrict.ToList();
        }

    }
}
