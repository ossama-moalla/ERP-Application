﻿using ERP_System.Models.Materials;
using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.AvailableItems
{
    public class AvailbeItems_StorePlace_ItemINDetails
    {
        public StorePlace Place;
        public Item _Item;
        public string ItemStoreType;
        public int StoreType;
        public int OprID;
        public string ParentOperationDesc;
        public int ParentOperationID;
        public string consumeunitname;
        public double StoredAmount;
        public double SpentAmount;
        public double AvailableAmount;
        public AvailbeItems_StorePlace_ItemINDetails(
         StorePlace Place_,
         Item Item_,
          string ItemStoreType_,
          int StoreType_,
           int OprID_,
         string ParentOperationDesc_,
         int ParentOperationID_,
         string consumeunitname_,
         double StoredAmount_,
         double SpentAmount_,
         double AvailableAmount_)
        {
            Place = Place_;
            _Item = Item_;
            ItemStoreType = ItemStoreType_;
            StoreType = StoreType_;
            OprID = OprID_;
            ParentOperationDesc = ParentOperationDesc_;
            ParentOperationID = ParentOperationID_;
            consumeunitname = consumeunitname_;
            StoredAmount = StoredAmount_;
            SpentAmount = SpentAmount_;
            AvailableAmount = AvailableAmount_;
        }
    }
}
