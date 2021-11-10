using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance.Reports
{
    public class MaintenanceFaultReport
    {
        public MaintenanceFault Fault { get; }
        public List<RepairOPR> MaintenanceFault_Affictive_RepairOPRList { get; }
        public int Tags_Count { get; }
        public MaintenanceFaultReport(MaintenanceFault Fault_, List<RepairOPR> MaintenanceFault_Affictive_RepairOPRList_, int Tags_Count_)
        {
            Fault = Fault_;
            MaintenanceFault_Affictive_RepairOPRList = MaintenanceFault_Affictive_RepairOPRList_;
            Tags_Count = Tags_Count_;
        }
    }
}
