using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting.Reports
{
    public class MoneyAccount_DayReport
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public List<MoneyAccountOperation> OperationsList { get; set; }
        public List<MoneyAccount_CurrencyReport> CurrencyReportList { get; set; }
    }
}
