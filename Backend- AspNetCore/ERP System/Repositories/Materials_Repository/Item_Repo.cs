using ERP_System.Models.Materials;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class Item_Repo : IApplicationRepositoryEntityAddReturn<Item>
    {
        Application_Identity_DbContext Db_Context;
        public Item_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public Item Add(Item entity)
        {
            Db_Context.Materials_Item.Add(entity);
            Db_Context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            Db_Context.Materials_Item.Remove(entity);
            Db_Context.SaveChanges();
        }

        public void Update(Item entity)
        {
            var item = GetByID(entity.Id);
            if(item!=null)
            {
                item.Name = entity.Name;
                item.ItemCategoryId = entity.ItemCategoryId;
                item.Company = entity.Company;
                item.ConsumeUnit = entity.ConsumeUnit;
                item.MarketCode = entity.MarketCode;
                Db_Context.SaveChanges();
            }
        }

        public Item GetByID(int id)
        {
            return Db_Context.Materials_Item.Include(x=>x.ItemCategory) .SingleOrDefault(x => x.Id == id);
        }

        public IList<Item> List()
        {
            return Db_Context.Materials_Item.ToList();
        }



    }
}
