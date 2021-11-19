using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class ExchangeOPR
    {
        public MoneyAccount _Money_Account;
        public int ExchangeOprID;
        public DateTime ExchangeOprDate;
        public Currency SourceCurrency;
        public double SourceExchangeRate;
        public double OutMoneyValue;
        public Currency TargetCurrency;
        public double TargetExchangeRate;
        public string Notes;
        public ExchangeOPR(MoneyAccount Money_Account_, int ExchangeOprID_, DateTime ExchangeOprDate_,
            Currency SourceCurrency_, double SourceExchangeRate_, double OutMoneyValue_, Currency TargetCurrency_, double TargetExchangeRate_, string Notes_)
        {
            _Money_Account = Money_Account_;
            ExchangeOprID = ExchangeOprID_;
            ExchangeOprDate = ExchangeOprDate_;
            SourceCurrency = SourceCurrency_;
            SourceExchangeRate = SourceExchangeRate_;
            OutMoneyValue = OutMoneyValue_;
            TargetCurrency = TargetCurrency_;
            TargetExchangeRate = TargetExchangeRate_;
            Notes = Notes_;
        }
    }
}
