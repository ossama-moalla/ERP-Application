using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.PurchasesBillsReport
{
    public class PurchasesBillsReport_InMonth : IPurchasesBillsReport,IMonthInfo
    {
        public int MonthNO { get; set; }
        public string MonthName { get; set; }
    }
}
