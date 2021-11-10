using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class MaintenanceFault
    {
        public MaintenanceOPR _MaintenanceOPR;
        public Item _Item;
        public uint FaultID;
        public DateTime FaultDate;
        public string FaultDesc;
        public string FaultReport;
        public MaintenanceFault(MaintenanceOPR MaintenanceOPR_, Item Item_,
           uint FaultID_, DateTime FaultDate_, string FaultDesc_, string FaultReport_)
        {
            _MaintenanceOPR = MaintenanceOPR_;
            _Item = Item_;
            FaultID = FaultID_;
            FaultDate = FaultDate_;
            FaultDesc = FaultDesc_;
            FaultReport = FaultReport_;
        }
    }
}
