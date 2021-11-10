using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class INCost
    {
        public double Value;
        public Currency _Currency;
        public double ExchangeRate;
        public INCost(double Value_,
         Currency Currency_,
         double ExchangeRate_)
        {
            Value = Value_;
            _Currency = Currency_;
            ExchangeRate = ExchangeRate_;
        }
    }
}
