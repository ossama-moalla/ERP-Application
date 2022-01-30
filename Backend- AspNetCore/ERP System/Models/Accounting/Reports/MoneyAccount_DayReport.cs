using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting.Reports
{
    public class MoneyAccount_DayReport
    {
        public List<MoneyAccountOperation> OperationsList { get; set; }
        public List<MoneyAccount_CurrencyReport> CurrencyReportList { get; set; }
    }
}
