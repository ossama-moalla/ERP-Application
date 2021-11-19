using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Store
{
    public class StorePlace_Item_VM
    {
        public const int ITEMIN_STORE_TYPE = 0;
        public const int MAINTENANCE_ITEM_STORE_TYPE = 1;
        public const int MAINTENANCE_ACCESSORIES_ITEM_STORE_TYPE = 2;
        ///// 
        public StorePlace _StorePlace;
        public int ItemSourceOPRID;
        public int StoreType;
        public double Amount;
        public ConsumeUnit _ConsumeUnit;
        public StorePlace_Item_VM(StorePlace StorePlace_, int ItemSourceOPRID_, int StoreType_, double Amount_, ConsumeUnit ConsumeUnit_)
        {

            _StorePlace = StorePlace_;
            ItemSourceOPRID = ItemSourceOPRID_;
            StoreType = StoreType_;
            Amount = Amount_;
            _ConsumeUnit = ConsumeUnit_;
        }
    }
}
