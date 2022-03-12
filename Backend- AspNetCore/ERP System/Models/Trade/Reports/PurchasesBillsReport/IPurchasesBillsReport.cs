using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.PurchasesBillsReport
{
    public class IPurchasesBillsReport:IBillsReport
    {
        public double Amount_IN{get;set;}
        public double Amount_Remain{get;set;}
        public string ItemsOut_Value{get;set;}
        public double ItemsOut_RealValue{get;set;}
        public string Proceeds_PaysValue{get;set;}
        public double Proceeds_PaysRealValue { get;set;}
    }
}
