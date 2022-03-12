using ERP_System.Models.Materials;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemCategorySpec_Repo : IApplicationRepository<ItemCategorySpec>
    {
        private readonly Application_Identity_DbContext Db_Context;
        public ItemCategorySpec_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public ItemCategorySpec Add(ItemCategorySpec entity)
        {
            Db_Context.Materials_ItemCategorySpec.Add(entity);
            Db_Context.SaveChanges();
            return entity;
            
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            if (entity == null) LocalException.ThrowNotFound("Delete Failed! Spec with Id:" + id + " Not Exists");
            Db_Context.Materials_ItemCategorySpec.Remove(entity);
            Db_Context.SaveChanges();
            
        }

        public void Update(ItemCategorySpec entity)
        {
            var spec = GetByID(entity.Id);
            if(spec==null) LocalException.ThrowNotFound("Update Failed! Spec with Id:" + entity.Id + " Not Exists");
            spec.Name = entity.Name;
            spec.Index = entity.Index;
            Db_Context.SaveChanges();
            
        }

        public ItemCategorySpec GetByID(int id)
        {
            return Db_Context.Materials_ItemCategorySpec.SingleOrDefault(x => x.Id == id);
        }


        public IList<ItemCategorySpec> List()
        {
            return Db_Context.Materials_ItemCategorySpec.ToList();
        }
    }
}
