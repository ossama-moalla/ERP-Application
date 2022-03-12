using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.PurchasesBillsReport
{
    public class PurchasesBillsReport_DayReport
    {

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }


        public List<PurchasesBill_Report> PurchasesBillReport_List { get; set; }
    }
}
