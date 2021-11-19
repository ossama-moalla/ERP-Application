using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class MaintenanceOPR_EndWork
    {
        public int MaintenanceOPRID { get; }
        public DateTime EndWorkDate { get; }
        public bool Repaired { get; }
        public string Report { get; }
        public DateTime? DeliveredDate { get; }
        public DateTime? EndwarrantyDate { get; }

        public MaintenanceOPR_EndWork(int MaintenanceOPRID_,
         DateTime EndWorkDate_,
         bool Repaired_,
         string Report_,
         DateTime? DeliveredDate_,
         DateTime? EndwarrantyDate_
         )
        {
            MaintenanceOPRID = MaintenanceOPRID_;
            EndWorkDate = EndWorkDate_;
            Repaired = Repaired_;
            DeliveredDate = DeliveredDate_;
            EndwarrantyDate = EndwarrantyDate_;
            Report = Report_;
        }

    }
}
