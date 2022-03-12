using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.SalesBillsReport
{
    public class SalesBillsReport_InDay : ISalesBillsReport, IDayInfo
    {

        public int DayNO { get; set; }
        public DateTime DayDate { get; set; }
    }
}
