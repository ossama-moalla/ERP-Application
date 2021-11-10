using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance.Reports
{
    public class DiagnosticOPRReport
    {
        public DiagnosticOPR _DiagnosticOPR;
        public int MeasureOPR_Count;
        public int Files_Count;
        public int SubDiagnosticOPR_Count;
        public int Tags_Count;
        public DiagnosticOPRReport(DiagnosticOPR DiagnosticOPR_,
         int MeasureOPR_Count_,
         int Files_Count_,
         int SubDiagnosticOPR_Count_,
         int Tags_Count_)
        {
            _DiagnosticOPR = DiagnosticOPR_;
            MeasureOPR_Count = MeasureOPR_Count_;
            Files_Count = Files_Count_;
            SubDiagnosticOPR_Count = SubDiagnosticOPR_Count_;
            Tags_Count = Tags_Count_;
        }
    }
}
