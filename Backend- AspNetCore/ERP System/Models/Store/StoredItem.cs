using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Store
{
    public class StoredItem
    {
        public const uint ITEMIN_STORE_TYPE = 0;
        public const uint MAINTENANCE_ITEM_STORE_TYPE = 1;
        public const uint MAINTENANCE_ACCESSORIES_ITEM_STORE_TYPE = 2;
        ///// 
        public StorePlace _StorePlace;
        public uint ItemSourceOPRID;
        public uint StoreType;
        public double Amount;
        public ConsumeUnit _ConsumeUnit;
        public StoredItem(StorePlace StorePlace_, uint ItemSourceOPRID_, uint StoreType_, double Amount_, ConsumeUnit ConsumeUnit_)
        {

            _StorePlace = StorePlace_;
            ItemSourceOPRID = ItemSourceOPRID_;
            StoreType = StoreType_;
            Amount = Amount_;
            _ConsumeUnit = ConsumeUnit_;
        }
    }
}
