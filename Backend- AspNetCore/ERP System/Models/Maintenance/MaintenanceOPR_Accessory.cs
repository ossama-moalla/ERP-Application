using ERP_System.Models.Materials;
using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class MaintenanceOPR_Accessory
    {
        public uint AccessoryID;
        public MaintenanceOPR _MaintenanceOPR;
        public Item _Item;
        public string ItemSerialNumber;
        public string Notes;
        public StorePlace Place;
        public MaintenanceOPR_Accessory(
         uint AccessoryID_,
         MaintenanceOPR MaintenanceOPR_,
         Item Item_,
         string ItemSerialNumber_,
         string Notes_,
         StorePlace Place_)
        {
            AccessoryID = AccessoryID_;
            _MaintenanceOPR = MaintenanceOPR_;
            _Item = Item_;
            ItemSerialNumber = ItemSerialNumber_;
            Notes = Notes_;
            Place = Place_;
        }
    }
}
