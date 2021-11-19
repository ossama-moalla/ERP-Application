using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemCategory_Repo : IApplicationRepository<ItemCategory>
    {
        Application_Identity_DbContext Db_Context;
        public ItemCategory_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public  void Add(ItemCategory entity)
        {
             Db_Context.Materials_ItemCategory.Add(entity);
             Db_Context.SaveChanges();
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
        //public string GetItemCategoryPath(ItemCategory ItemCategory_)
        //{
        //    return "";
        //}
        //public string GetItemCategoryPath(ItemCategory RootItemCategory, ItemCategory ItemCategory_)
        //{
        //    return "";
        //}
        //internal List<ItemCategory> Get_User_Allowed_ItemCategorys(int userid)
        //{
        //    return new List<ItemCategory>();
        //}
        //public ItemCategory GetParentItemCategory(ItemCategory f)
        //{
        //    return new ItemCategory();
        //}
        //public List<ItemCategory> GetItemCategoryChilds(ItemCategory ItemCategory)
        //{
        //    return new List<ItemCategory>();
        //}
        //public List<ItemCategory> Get_ItemCategory_Tree(ItemCategory ItemCategory)
        //{
        //    return new List<ItemCategory>();
        //}
        //public List<ItemCategory> SearchItemCategory(ItemCategory RootItemCategory, string n_)
        //{
        //    return new List<ItemCategory>();
        //}
        //public bool IS_Move_Able(ItemCategory DestinationItemCategory, ItemCategory ItemCategory)
        //{
        //    return true;
        //}
        //public bool MoveItemCategorys(ItemCategory DestinationItemCategory, List<ItemCategory> ItemCategorysList)
        //{
        //    return true;
        //}
    }
}
