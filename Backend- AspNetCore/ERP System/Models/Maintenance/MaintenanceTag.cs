using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class MaintenanceTag
    {
        public uint TagID { get; }
        public MaintenanceFault _MaintenanceFault { get; }
        public DiagnosticOPR _DiagnosticOPR { get; }
        public Missed_Fault_Item _Missed_Fault_Item { get; }
        public string TagInfo;
        public MaintenanceTag(uint TagID_, string TagInfo_, MaintenanceFault MaintenanceFault_, DiagnosticOPR DiagnosticOPR_, Missed_Fault_Item Missed_Fault_Item_)
        {
            TagID = TagID_;
            TagInfo = TagInfo_;
            _MaintenanceFault = MaintenanceFault_;
            _DiagnosticOPR = DiagnosticOPR_;
            _Missed_Fault_Item = Missed_Fault_Item_;
        }
    }
}
