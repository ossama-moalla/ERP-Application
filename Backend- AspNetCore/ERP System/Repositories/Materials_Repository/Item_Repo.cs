using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class Item_Repo : IApplicationRepository<Item>
    {
        Application_Identity_DbContext Db_Context;
        public Item_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public void Add(Item entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Item entity)
        {
            throw new NotImplementedException();
        }

        public Item GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Item> List()
        {
            throw new NotImplementedException();
        }

        public List<Item> FilterItemsBySpec(List<ItemSpec_Restrict_Options> ItemSpec_Restrict_Options_List, List<ItemSpec_Value> ItemSpec_Value_List)
        {
            return new List<Item>();
        }
        public List<Item> Get_ItemCategory_Items(ItemCategory category)
        {
            return new List<Item>();

        }

        public List<Item> SearchItem(ItemCategory ItemCategory, string n)
        {
            return new List<Item>();

        }
        public void MoveItems(ItemCategory DestinationItemCategory, List<Item> ItemsList)
        {
            
        }
        public byte[] GetItemImage(Item Item_)
        {
            byte[] image= { 0x00 };
            return  image;
        }
        public void SetItemImage(uint ItemID, byte[] Image_)
        {

        }
        public void UnSetItemImage(uint ItemID)
        {

        }
    }
}
