using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports
{
    public class ITradeOperationReport
    {
        public DateTime Time { get; set; }
        public int Id { get; set; }
        public string Owner { get; set; }
        public int Clauses_Count { get; set; }
        public double Bill_Value { get; set; }
        public string TotalPays { get; set; }
        public double Bill_Value_Remain { get; set; }
        public Currency Currency { get; set; }
        public double ExchangeRate { get; set; }
        public double Bill_RealValue { get; set; }
        public double Pays_RealValue { get; set; }

    }
}
