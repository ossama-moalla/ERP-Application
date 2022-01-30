using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting.Reports
{
    public class MoneyAccount_YearReport
    {
        public List<MoneyAccountReport_InMonth> MoneyAccountReport_InMonth_List { get; set; }
        public List<MoneyAccount_CurrencyReport> CurrencyReportList { get; set; }
    }
}
