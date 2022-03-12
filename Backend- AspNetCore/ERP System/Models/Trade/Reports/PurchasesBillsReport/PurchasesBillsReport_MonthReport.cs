using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.PurchasesBillsReport
{
    public class PurchasesBillsReport_MonthReport
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public List<PurchasesBillsReport_InDay> PurchasesBillsReport_InDay_List { get; set; }
    }
}
