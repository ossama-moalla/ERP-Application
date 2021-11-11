using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Store
{
    public class StorePlace_Item_Details
    {
        public const uint ITEMIN_STORE_TYPE = 0;
        public const uint MAINTENANCE_ITEM_STORE_TYPE = 1;
        public const uint MAINTENANCE_ACCESSORIES_ITEM_STORE_TYPE = 2;
        public uint PlaceID { get; }
        public uint ItemSourceOPR_ID { get; }
        public uint StoreType { get; }
        public uint Source_OperationType { get; }
        public uint Source_OperationID { get; }
        public string ConsumUnitName { get; }
        public uint ItemID { get; }
        public string FolderName { get; }
        public string ItemName { get; }
        public string ItemCompany { get; }
        public uint TradeStateID { get; }
        public string TradeStateName { get; }
        public double AvailableAmount { get; }
        public double SpentAmount { get; }

        public StorePlace_Item_Details(
             uint PlaceID_,
         uint ItemSourceOPR_ID_,
         uint StoreType_,
         uint Source_OperationType_,
         uint Source_OperationID_,
         string ConsumUnitName_,
         uint ItemID_,
         string FolderName_,
         string ItemName_,
         string ItemCompany_,
          uint TradeStateID_,
         string TradeStateName_,
        double AvailableAmount_,
         double SpentAmount_
     )
        {
            PlaceID = PlaceID_;
            ItemSourceOPR_ID = ItemSourceOPR_ID_;
            StoreType = StoreType_;
            Source_OperationType = Source_OperationType_;
            Source_OperationID = Source_OperationID_;
            ConsumUnitName = ConsumUnitName_;
            ItemID = ItemID_;
            FolderName = FolderName_;
            ItemName = ItemName_;
            ItemCompany = ItemCompany_;
            TradeStateID = TradeStateID_;
            TradeStateName = TradeStateName_;
            AvailableAmount = AvailableAmount_;
            SpentAmount = SpentAmount_;
        }
    }
}
