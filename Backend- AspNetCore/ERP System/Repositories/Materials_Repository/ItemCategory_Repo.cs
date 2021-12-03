using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemCategory_Repo : IApplicationRepositoryEntityAddReturn<ItemCategory>
    {
        Application_Identity_DbContext Db_Context;
        public ItemCategory_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public ItemCategory Add(ItemCategory entity)
        {
             Db_Context.Materials_ItemCategory.Add(entity);
             Db_Context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var itemcategory = GetByID(id);
            Db_Context.Materials_ItemCategory.Remove(itemcategory);
            Db_Context.SaveChanges();
        }

        public void Update(ItemCategory entity)
        {
            Db_Context.Materials_ItemCategory.Update(entity);
            Db_Context.SaveChanges();
        }

        public ItemCategory GetByID(int id)
        {
            return Db_Context.Materials_ItemCategory.SingleOrDefault(x => x.ID == id);
        }

        public IList<ItemCategory> List()
        {
            return Db_Context.Materials_ItemCategory.ToList();
        }
        
    }
}
