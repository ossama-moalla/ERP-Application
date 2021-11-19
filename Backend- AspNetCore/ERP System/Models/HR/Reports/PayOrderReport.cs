using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.Reports
{
    public class PayOrderReport
    {
        public enum Pay_Order_Type:ushort
        {

            SALARY = 0,
            NON_SALARY = 1
        }
        public bool PayOrderType;
        public int PayOrderID;
        public DateTime PayOrderDate;
        public string PayOrderDesc;
        public int EmployeeID;
        public string EmployeeName;
        public Currency _Currency;
        public double ExchangeRate;
        public double Value;
        public string PaysAmount;
        public PayOrderReport(bool PayOrderType_,
            int PayOrderID_,
         DateTime PayOrderDate_,
         string PayOrderDesc_,
         int EmployeeID_,
         string EmployeeName_,
         Currency Currency_,
        double ExchangeRate_,
         double Value_,
         string PaysAmount_)
        {
            PayOrderType = PayOrderType_;
            PayOrderID = PayOrderID_;
            PayOrderDate = PayOrderDate_;
            PayOrderDesc = PayOrderDesc_;
            EmployeeID = EmployeeID_;
            EmployeeName = EmployeeName_;
            _Currency = Currency_;
            ExchangeRate = ExchangeRate_;
            Value = Value_;
            PaysAmount = PaysAmount_;
        }

    }
}
