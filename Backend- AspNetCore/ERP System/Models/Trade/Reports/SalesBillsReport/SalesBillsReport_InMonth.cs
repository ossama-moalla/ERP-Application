using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.SalesBillsReport
{
    public class SalesBillsReport_InMonth : ISalesBillsReport, IMonthInfo
    {
        public int MonthNO { get; set; }
        public string MonthName { get; set; }
    }
}
