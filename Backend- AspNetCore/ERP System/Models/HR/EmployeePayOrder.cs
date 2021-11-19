using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR
{
    public class EmployeePayOrder
    {
        public int PayOrderID;
        public DateTime PayOrderDate;
        public SalarysPayOrder _SalarysPayOrder;
        public string PayOrderDesc;
        public Employee _Employee;
        public Currency _Currency;
        public double ExchangeRate;
        public double Value;
        public EmployeePayOrder(int PayOrderID_,
         DateTime PayOrderDate_,
         SalarysPayOrder SalarysPayOrder_,
         string PayOrderDesc_,
         Employee Employee_,
         Currency Currency_,
         double ExchangeRate_,
         double Value_)
        {
            PayOrderID = PayOrderID_;
            PayOrderDate = PayOrderDate_;
            _SalarysPayOrder = SalarysPayOrder_;
            PayOrderDesc = PayOrderDesc_;
            _Employee = Employee_;
            _Currency = Currency_;
            ExchangeRate = ExchangeRate_;
            Value = Value_;
        }

    }
}
