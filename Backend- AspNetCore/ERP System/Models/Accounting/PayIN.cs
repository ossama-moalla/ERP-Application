using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class PayIN
    {
        public MoneyAccount _Money_Account;
        public uint PayOprID;
        public DateTime PayOprDate;
        public IBill _Bill;
        public string PayDescription;
        public double Value;
        public Currency _Currency;
        public double ExchangeRate;
        public string Notes;

        public PayIN(MoneyAccount Money_Account_, uint PayOprID_, DateTime PayOprDate_, IBill Bill_, string PayDescription_, double Value_, double ExchangeRate_, Currency Currency_, string Notes_)
        {

            _Money_Account = Money_Account_;
            PayOprID = PayOprID_;
            PayOprDate = PayOprDate_;
            _Bill = Bill_;
            PayDescription = PayDescription_;
            Value = Value_;
            _Currency = Currency_;
            ExchangeRate = ExchangeRate_;
            Notes = Notes_;
        }

    }
}
