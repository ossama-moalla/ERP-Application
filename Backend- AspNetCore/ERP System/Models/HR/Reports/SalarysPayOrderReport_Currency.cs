using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.Reports
{
    public class SalarysPayOrderReport_Currency
    {
        public uint CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;
        public double SalarysValue;
        public string PaysValue;
        public double RealSalarysValue;
        public double RealPaysValue;
        public SalarysPayOrderReport_Currency(
             uint CurrencyID_,
         string CurrencyName_,
         string CurrencySymbol_,
         double SalarysValue_,
         string PaysValue_,
         double RealSalarysValue_,
         double RealPaysValue_)
        {
            CurrencyID = CurrencyID_;
            CurrencyName = CurrencyName_;
            CurrencySymbol = CurrencySymbol_;
            SalarysValue = SalarysValue_;
            PaysValue = PaysValue_;
            RealSalarysValue = RealSalarysValue_;
            RealPaysValue = RealPaysValue_;
        }
    }
}
