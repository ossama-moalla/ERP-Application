using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class Currency
    {
        public int CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;
        public double ExchangeRate;
        public int? ReferenceCurrencyID;
        public bool Disable;
        public Currency(int CurrencyID_, string CurrencyName_, string CurrencySymbol_, double ExchangeRate_, int? ReferenceCurrencyID_, bool Disable_)
        {
            CurrencyID = CurrencyID_;
            CurrencyName = CurrencyName_;
            CurrencySymbol = CurrencySymbol_;
            ExchangeRate = ExchangeRate_;
            ReferenceCurrencyID = ReferenceCurrencyID_;
            Disable = Disable_;
        }

    }
}
