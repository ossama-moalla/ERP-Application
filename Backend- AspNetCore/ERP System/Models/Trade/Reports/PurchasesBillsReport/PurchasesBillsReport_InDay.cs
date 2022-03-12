using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.PurchasesBillsReport
{
    public class PurchasesBillsReport_InDay : IPurchasesBillsReport,IDayInfo
    {
        public int DayNO { get; set; }
        public DateTime DayDate { get; set; }
    }
}
