using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class Currency
    {
        public uint CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;
        public double ExchangeRate;
        public uint? ReferenceCurrencyID;
        public bool Disable;
        public Currency(uint CurrencyID_, string CurrencyName_, string CurrencySymbol_, double ExchangeRate_, uint? ReferenceCurrencyID_, bool Disable_)
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
