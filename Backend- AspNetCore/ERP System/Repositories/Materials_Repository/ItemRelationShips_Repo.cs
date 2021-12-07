using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemRelationShips_Repo : IApplicationRepository<ItemCategorySpec>
    {
        Application_Identity_DbContext Db_Context;
        public ItemRelationShips_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }

        public void Add(ItemCategorySpec entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemCategorySpec entity)
        {
            throw new NotImplementedException();
        }

        public ItemCategorySpec GetByID(int id)
        {
            throw new NotImplementedException();
        }
        //internal ItemRelation GetItemRealtion(Item sourceItem, Item anotherItem)
        //{
        //    throw new NotImplementedException();

        //}
        //public List<ItemRelation> GetItemRelationsList(Item item)
        //{

        //    return new List<ItemRelation>();
        
        //}

        public IList<ItemCategorySpec> List()
        {
            throw new NotImplementedException();
        }
    }
}
