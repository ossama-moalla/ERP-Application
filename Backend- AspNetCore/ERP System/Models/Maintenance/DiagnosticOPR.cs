using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class DiagnosticOPR
    {
        public MaintenanceOPR _MaintenanceOPR;
        public int? ParentDiagnosticOPRID;
        public int DiagnosticOPRID;
        public DateTime DiagnosticOPRDate;
        public Item _Item;
        public string Desc;
        public string Location;
        public bool? Normal;
        public string Report;
        public DiagnosticOPR(
            MaintenanceOPR MaintenanceOPR_,
            int? ParentDiagnosticOPRID_,
            int DiagnosticOPRID_,
            DateTime DiagnosticOPRDate_,
             Item Item_,
            string Desc_,
             string Location_,
             bool? Normal_,
         string Report_)
        {
            _MaintenanceOPR = MaintenanceOPR_;
            ParentDiagnosticOPRID = ParentDiagnosticOPRID_;
            DiagnosticOPRID = DiagnosticOPRID_;
            DiagnosticOPRDate = DiagnosticOPRDate_;
            _Item = Item_;
            Desc = Desc_;
            Location = Location_;
            Normal = Normal_;
            Report = Report_;
        }

    }
}
