using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.SalesBillsReport
{
    public class SalesBillsReport_YearRangeReport
    {
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public List<SalesBillsReport_InYear> SalesBillsReport_InYear_List { get; set; }
    }
}
