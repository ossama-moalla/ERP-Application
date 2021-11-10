using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class RepairOPR
    {
        public Operation _Operation { get; }
        public MaintenanceOPR _MaintenanceOPR { get; }
        public DateTime RepairOPRDate { get; }
        public string RepairDesc { get; }
        public string RepairReport { get; }
        public int InstalledItem_Count { get; }
        public int TestInstallOPR_Count { get; }
        public RepairOPR(uint RepairOPRID,
         MaintenanceOPR MaintenanceOPR_,
         DateTime RepairOPRDate_,
         string RepairDesc_,
         string RepairReport_,
         int InstalledItem_Count_,
         int TestInstallOPR_Count_
         )
        {
            _Operation = new Operation(Operation.REPAIROPR, RepairOPRID);
            _MaintenanceOPR = MaintenanceOPR_;
            RepairOPRDate = RepairOPRDate_;
            RepairDesc = RepairDesc_;
            RepairReport = RepairReport_;
            TestInstallOPR_Count = TestInstallOPR_Count_;
            TestInstallOPR_Count = TestInstallOPR_Count_;
        }
    }
}
