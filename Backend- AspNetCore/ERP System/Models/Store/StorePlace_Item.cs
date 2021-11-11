using ERP_System.Models.Maintenance;
using ERP_System.Models.Materials;
using ERP_System.Models.Store;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Store
{
    public class StorePlace_Item
    {
        public const uint ITEMIN_STORE_TYPE = 0;
        public const uint MAINTENANCE_ITEM_STORE_TYPE = 1;
        public const uint MAINTENANCE_ACCESSORIES_ITEM_STORE_TYPE = 2;
        ///// 
        public StorePlace _StorePlace { get; }
        public ItemIN _ItemIN { get; }
        public MaintenanceOPR _MaintenanceOPR { get; }
        public MaintenanceOPR_Accessory _MaintenanceOPR_Accessory { get; }
        public uint StoreType { get; }
        public double Amount { get; }
        public ConsumeUnit _ConsumeUnit { get; }
        public StorePlace_Item(StorePlace StorePlace_, ItemIN ItemIN_, double Amount_, ConsumeUnit ConsumeUnit_)
        {

            _StorePlace = StorePlace_;
            _ItemIN = ItemIN_;
            StoreType = ITEMIN_STORE_TYPE;
            Amount = Amount_;
            _ConsumeUnit = ConsumeUnit_;
        }
        public StorePlace_Item(StorePlace StorePlace_, MaintenanceOPR MaintenanceOPR_, double Amount_, ConsumeUnit ConsumeUnit_)
        {

            _StorePlace = StorePlace_;
            _MaintenanceOPR = MaintenanceOPR_;
            StoreType = MAINTENANCE_ITEM_STORE_TYPE;
            Amount = Amount_;
            _ConsumeUnit = ConsumeUnit_;
        }
        public StorePlace_Item(StorePlace StorePlace_, MaintenanceOPR_Accessory MaintenanceOPR_Accessory_, double Amount_, ConsumeUnit ConsumeUnit_)
        {

            _StorePlace = StorePlace_;
            _MaintenanceOPR_Accessory = MaintenanceOPR_Accessory_;
            StoreType = MAINTENANCE_ACCESSORIES_ITEM_STORE_TYPE;
            Amount = Amount_;
            _ConsumeUnit = ConsumeUnit_;
        }


    }
}
