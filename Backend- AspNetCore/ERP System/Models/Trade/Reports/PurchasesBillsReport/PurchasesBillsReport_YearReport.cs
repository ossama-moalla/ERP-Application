using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.PurchasesBillsReport
{
    public class PurchasesBillsReport_YearReport
    {
        public int Year { get; set; }
        public List<PurchasesBillsReport_InMonth> PurchasesBillsReport_InMonth_List { get; set; }
    }
}
