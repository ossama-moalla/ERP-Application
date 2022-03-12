using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.PurchasesBillsReport
{
    public class PurchasesBill_Report:ITradeOperationReport
    {
        public double Amount_IN{get;set;}
        public double Amount_Remain{get;set;}
        public string ItemsOut_Value{get;set;}
        public double ItemsOut_RealValue{get;set;}
        public string Porceeds_Value{get;set;}
        public double Porceeds_RealValue { get;set;}

    }
}
