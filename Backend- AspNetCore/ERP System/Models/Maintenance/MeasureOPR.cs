using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class MeasureOPR
    {
        public DiagnosticOPR _DiagnosticOPR;
        public int MeasureID;
        public string Desc;
        public string Value;
        public string MeasureUnit;
        public bool? Normal;
        public MeasureOPR(
              DiagnosticOPR DiagnosticOPR_,
         int MeasureID_,
         string Desc_,
         string Value_,
         string MeasureUnit_,
            bool? Normal_)
        {
            _DiagnosticOPR = DiagnosticOPR_;
            MeasureID = MeasureID_;
            Desc = Desc_;
            Value = Value_;
            MeasureUnit = MeasureUnit_;
            Normal = Normal_;
        }
    }
}
