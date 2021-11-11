using ERP_System.Models.AvailableItems;
using ERP_System.Models.Materials;
using ERP_System.Models.Store;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Store_Repository
{
    public class StorePlace_Item_Repo 
    {
        Application_Identity_DbContext DbContext;
        public StorePlace_Item_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public StorePlace_Item GetTradeItemStoreINFO(StorePlace place, uint ItemSourceOPRID_, uint StoreType_)
        {
            throw new NotImplementedException();
        }

        public bool IS_ItemStoredInPlace(uint PlaceID, uint ItemSourceOPRID_, uint StoreType_)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItemAmountStored(uint PlaceID, uint ItemSourceOPRID_, uint StoreType_, double amount, ConsumeUnit ConsumeUnit_)
        {
            throw new NotImplementedException();
        }

        public bool Store_Item_INPlace(uint PlaceID, uint ItemSourceOPRID_, uint StoreType_, double amount, ConsumeUnit ConsumeUnit_)
        {
            throw new NotImplementedException();
        }
        public bool UNStore_Item_INPlace(uint PlaceID, uint ItemSourceOPRID_, uint StoreType_)
        {
            throw new NotImplementedException();
        }
        public List<StorePlace_Item_Details> Get_TradeItemStore_Report_List()
        {
            throw new NotImplementedException();
        }
        public List<StorePlace_Item_AvailableAmount_Report> GetItemsStoredINPlace(StorePlace place)
        {
            throw new NotImplementedException();
        }
        public List<StorePlace_Item_AvailableAmount_Report> GetItemsStoredINPlace_BY_Item(StorePlace place, Item item)
        {
            throw new NotImplementedException();
        }
        public List<StorePlace_Item> Get_ItemIN_StoredPlaces(ItemIN ItemIN_)
        {
            throw new NotImplementedException();
        }
        public StorePlace GetMaintenanceStorePlace(UInt32 maintenenaceoprid)
        {
            throw new NotImplementedException();
        }
        public StorePlace GetAccessoryStorePlace(UInt32 AccessoryID)
        {
            throw new NotImplementedException();
        }
        internal void Clear_Places()
        {
            throw new NotImplementedException();
        }
    }
}
