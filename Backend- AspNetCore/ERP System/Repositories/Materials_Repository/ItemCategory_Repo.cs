using ERP_System.Models.Materials;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemCategory_Repo : IApplicationRepositoryEntityAddReturn<ItemCategory>
    {
        Application_Identity_DbContext Db_Context;
        private readonly ILogger logger;
        public ItemCategory_Repo(Application_Identity_DbContext Db_Context_, ILogger<ItemCategory_Repo> _logger)
        {
            Db_Context = Db_Context_;
            logger = _logger;
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
            var category = GetByID(entity.Id);
            if(category!=null)
            {
                category.name = entity.name;
                category.defaultConsumeUnit = entity.defaultConsumeUnit;
                category.parentID = entity.parentID;
                Db_Context.SaveChanges();
            }
        }

        public ItemCategory GetByID(int id)
        {
            return Db_Context.Materials_ItemCategory.SingleOrDefault(x => x.Id == id);
        }

        public IList<ItemCategory> List()
        {
            return Db_Context.Materials_ItemCategory.Select(x=>x).ToList();
        }
        
    }
}
