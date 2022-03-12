using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.SalesBillsReport
{
    public class SalesBillsReport_YearReport
    {
        public int Year { get; set; }
        public List<SalesBillsReport_InMonth> SalesBillsReport_InMonth_List { get; set; }
    }
}
