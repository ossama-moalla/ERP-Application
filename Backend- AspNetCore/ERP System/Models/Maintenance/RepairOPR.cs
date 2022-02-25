using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class RepairOPR
    {
        public Operation Operation { get; }
        public MaintenanceOPR MaintenanceOPR { get; }
        public DateTime RepairOPRDate { get; }
        public string RepairDesc { get; }
        public string RepairReport { get; }
        public int InstalledItem_Count { get; }
        public int TestInstallOPR_Count { get; }
        
    }
}
