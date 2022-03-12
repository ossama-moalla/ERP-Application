using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.PurchasesBillsReport
{
    public class PurchasesBillsReport_YearRangeReport
    {
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public List<PurchasesBillsReport_InYear> PurchasesBillsReport_InYear_List { get; set; }
    }
}
