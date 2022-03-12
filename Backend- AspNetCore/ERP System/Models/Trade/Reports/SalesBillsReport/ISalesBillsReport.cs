using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.SalesBillsReport
{
    public class ISalesBillsReport:IBillsReport
    {
        public string Bills_ItemsIN_Value { get; set; }
        public double Bills_ItemsIN_RealValue { get; set; }
    }
}
