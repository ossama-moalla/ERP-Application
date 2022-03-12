using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.SalesBillsReport
{
    public class SalesBillsReport_MonthReport
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public List<SalesBillsReport_InDay> SalesBillsReport_InDay_List { get; set; }
    }
}
