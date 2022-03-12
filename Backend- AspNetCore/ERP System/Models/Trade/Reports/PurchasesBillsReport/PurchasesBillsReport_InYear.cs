using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.PurchasesBillsReport
{
    public class PurchasesBillsReport_InYear : IPurchasesBillsReport,IYearInfo
    {
        public int YearNO { get; set; }
    }  
}
