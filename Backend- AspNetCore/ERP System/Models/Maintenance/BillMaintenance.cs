using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class BillMaintenance
    {
        public SellType SellType { get; set; }
        public MaintenanceOPR MaintenanceOPR { get; set; }
    }
}
