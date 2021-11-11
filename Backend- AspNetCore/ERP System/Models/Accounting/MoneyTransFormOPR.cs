using ERP_System.Models.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class MoneyTransFormOPR
    {
        public Employee Creator_Employee;
        public uint MoneyTransFormOPRID;
        public DateTime MoneyTransFormOPRDate;
        public MoneyAccount SourceMoney_Account;
        public MoneyAccount TargetMoney_Account;
        public double Value;
        public Currency _Currency;
        public double ExchangeRate;
        public string Notes;
        public Employee Confirm_Employee;
        public MoneyTransFormOPR(
            Employee Creator_Employee_,
        uint MoneyTransFormOPRID_,
         DateTime MoneyTransFormOPRDate_,
         MoneyAccount SourceMoney_Account_,
         MoneyAccount TargetMoney_Account_,
         double Value_,
         double ExchangeRate_,
         Currency Currency_,
         string Notes_,
         Employee Confirm_Employee_)
        {
            Creator_Employee = Creator_Employee_;
            MoneyTransFormOPRID = MoneyTransFormOPRID_;
            MoneyTransFormOPRDate = MoneyTransFormOPRDate_;
            SourceMoney_Account = SourceMoney_Account_;
            TargetMoney_Account = TargetMoney_Account_;
            Value = Value_;
            _Currency = Currency_;
            ExchangeRate = ExchangeRate_;
            Notes = Notes_;
            Confirm_Employee = Confirm_Employee_;
        }
    }
}
