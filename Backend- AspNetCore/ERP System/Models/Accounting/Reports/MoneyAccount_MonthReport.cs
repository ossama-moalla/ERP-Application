using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting.Reports
{
    public class MoneyAccount_MonthReport
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public List<MoneyAccountReport_InDay> MoneyAccountReport_InDay_List { get; set; }
        public List<MoneyAccount_CurrencyReport> CurrencyReportList { get; set; }
    }
}
