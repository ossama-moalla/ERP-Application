using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemCategorySpec_Repo : IApplicationRepository<ItemCategorySpec>
    {
        Application_Identity_DbContext Db_Context;
        public ItemCategorySpec_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public void Add(ItemCategorySpec entity)
        {
            Db_Context.Materials_ItemCategorySpec.Add(entity);
            Db_Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Db_Context.Materials_ItemCategorySpec.Remove(GetByID(id));
            Db_Context.SaveChanges(); 
        }

        public void Update(ItemCategorySpec entity)
        {
            var spec = GetByID(entity.id);
            if(spec!=null)
            {

                spec.name = entity.name;
                spec.index = entity.index;
                Db_Context.SaveChanges();
            }
        }

        public ItemCategorySpec GetByID(int id)
        {
            return Db_Context.Materials_ItemCategorySpec.SingleOrDefault(x => x.id == id);
        }


        public IList<ItemCategorySpec> List()
        {
            return Db_Context.Materials_ItemCategorySpec.ToList();
        }
    }
}
