using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports
{
    public class IBillsReport
    {
        public int Bills_Count { get; set; }
        public string Bills_Value { get; set; }
        public string Bills_Pays_Value { get; set; }
        public string Bills_Value_Remain { get; set; }
        public double Bills_RealValue { get; set; }
        public double Bills_Pays_RealValue { get; set; }

    }
}
