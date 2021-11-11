using ERP_System.Models.AvailableItems;
using ERP_System.Models.Materials;
using ERP_System.Models.Store;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.AvailableItem_Repository
{
    public class AvailableItem_Repo
    {
        Application_Identity_DbContext DbContext;
        public AvailableItem_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public double Get_AvailabeAmount_by_Place(ItemIN ItemIN_, StorePlace place)
        {
            throw new NotImplementedException();
        }
        public double Get_SpentAmount_by_Place(ItemIN ItemIN_, StorePlace place)
        {
            throw new NotImplementedException();
        }
        public double Get_AvailabeAmount_by_ItemIN(ItemIN ItemIN_)
        {
            throw new NotImplementedException();
        }
        public string Get_AvailabeAmount_For_Item(uint itemid)
        {
            throw new NotImplementedException();
        }
        public string Get_AvailabeAmount_For_Item_IN_Place(uint itemid, uint placeid)
        {
            throw new NotImplementedException();
        }
        internal List<ItemIN_AvailableAmount_Report> Get_ItemIN_AvailableAmount_Report_List()
        {
            throw new NotImplementedException();
        }
        internal List<ItemIN_AvailableAmount_Report_PlaceDetail> Get_ItemIN_AvailableAmount_Report_PlaceDetail_List()
        {
            throw new NotImplementedException();
        }
        internal List<Item_AvailableAmount_Report> Get_Item_AvailableAmount_Report_List()
        {
            throw new NotImplementedException();
        }
        internal List<Item_AvailableAmount_Report> Get_Item_AvailableAmount_Report_List_CUSTOM(List<Item> ItemList)
        {
            throw new NotImplementedException();
        }
    }
}
