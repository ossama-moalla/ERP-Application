using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting.Reports
{
    public class IMoneyAccountReport
    {
        public int PaysIN_Count { get; set; }
        public int PaysOUT_Count { get; set; }
        public int ExchangeOPR_Count { get; set; }
        public int MoneyTransform_IN_Count { get; set; }
        public int MoneyTransform_OUT_Count { get; set; }
        public string MoneyIN_Value { get; set; }
        public double MoneyIN_Real_Value { get; set; }
        public string MoneyOUT_Value { get; set; }
        public double MoneyOUT_Real_Value { get; set; }
    }
}
