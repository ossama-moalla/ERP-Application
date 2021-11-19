using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Store
{
    public class StorePlace_Item_Details
    {
        public const int ITEMIN_STORE_TYPE = 0;
        public const int MAINTENANCE_ITEM_STORE_TYPE = 1;
        public const int MAINTENANCE_ACCESSORIES_ITEM_STORE_TYPE = 2;
        public int PlaceID { get; }
        public int ItemSourceOPR_ID { get; }
        public int StoreType { get; }
        public int Source_OperationType { get; }
        public int Source_OperationID { get; }
        public string ConsumUnitName { get; }
        public int ItemID { get; }
        public string FolderName { get; }
        public string ItemName { get; }
        public string ItemCompany { get; }
        public int TradeStateID { get; }
        public string TradeStateName { get; }
        public double AvailableAmount { get; }
        public double SpentAmount { get; }

        public StorePlace_Item_Details(
             int PlaceID_,
         int ItemSourceOPR_ID_,
         int StoreType_,
         int Source_OperationType_,
         int Source_OperationID_,
         string ConsumUnitName_,
         int ItemID_,
         string FolderName_,
         string ItemName_,
         string ItemCompany_,
          int TradeStateID_,
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
