using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting.Reports
{
    public class MoneyAccount_CurrencyReport
    {
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }

        public double MoneyIN_FromSells{ get; set; }
        public double MoneyIN_FromMaintenance{ get; set; }
        public double MoneyIN_FromMoneyTransform{ get; set; }
        public double MoneyIN_FromOther{ get; set; }
        public double MoneyIN_FromExchangeOPR{ get; set; }
        public double MoneyOUT_ByBuy{ get; set; }
        public double MoneyOUT_ByEmpPayOrders{ get; set; }
        public double MoneyOUT_ByMoneyTransform{ get; set; }
        public double MoneyOUT_ByOther{ get; set; }
        public double MoneyOUT_ByExchangeOPR{ get; set; }
    }
}
