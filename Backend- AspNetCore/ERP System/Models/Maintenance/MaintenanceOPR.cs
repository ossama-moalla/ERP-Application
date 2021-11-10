using ERP_System.Models.Customers;
using ERP_System.Models.Materials;
using ERP_System.Models.Store;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class MaintenanceOPR
    {
        public Operation _Operation { get; }
        public DateTime EntryDate { get; }
        public Customer _Customer { get; }
        public Item _Item { get; }
        public string ItemSerial { get; }
        public string FaultDesc { get; }
        public StorePlace Place { get; }
        public MaintenanceOPR_EndWork _MaintenanceOPR_EndWork { get; set; }
        public string Notes { get; }
        public MaintenanceOPR(uint MaintenanceOPRID_
            , DateTime EntryDate_
             , Customer Customer_
            , Item Item_
            , string ItemSerial_
            , string FaultDesc_
            , StorePlace Place_
            , MaintenanceOPR_EndWork MaintenanceOPR_EndWork_
            , string Notes_)
        {
            _Operation = new Operation(Operation.MAINTENANCE_OPR, MaintenanceOPRID_);
            EntryDate = EntryDate_;
            _Customer = Customer_;
            _Item = Item_;
            ItemSerial = ItemSerial_;
            FaultDesc = FaultDesc_; ;
            Place = Place_;
            _MaintenanceOPR_EndWork = MaintenanceOPR_EndWork_;
            Notes = Notes_;

        }
    }
}
