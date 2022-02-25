using ERP_System.Models.Trade;
using ERP_System.Models.Materials;
using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class MaintenanceOPR
    {
        public Operation Operation { get; }
        public DateTime EntryDate { get; }
        public Dealer Dealer { get; }
        public Item Item { get; }
        public string ItemSerial { get; }
        public string FaultDesc { get; }
        public StorePlace Place { get; }
        public MaintenanceOPR_EndWork MaintenanceOPR_EndWork { get; set; }
        public string Notes { get; }
        
    }
}
