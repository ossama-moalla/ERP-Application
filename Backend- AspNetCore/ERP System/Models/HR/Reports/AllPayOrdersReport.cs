using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.Reports
{
    public class AllPayOrdersReport
    {
        public string Payorders_Value;
        public string Payorders_PaysAmount;
        public string Payorders_PaysRemain;
        public double Payorders_RealValue;
        public double Payorders_Pays_RealValue;
        public AllPayOrdersReport(string Payorders_Value_,
         string Payorders_PaysAmount_,
         string Payorders_PaysRemain_,
         double Payorders_RealValue_,
         double Payorders_Pays_RealValue_)
        {
            Payorders_Value = Payorders_Value_;
            Payorders_PaysAmount = Payorders_PaysAmount_;
            Payorders_PaysRemain = Payorders_PaysRemain_;
            Payorders_RealValue = Payorders_RealValue_;
            Payorders_Pays_RealValue = Payorders_RealValue_;
        }
    }
}
