using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.Reports
{
    public class SalarysPayOrderMonthReport
    {
        public int Year;
        public int MonthNO;
        public string MonthName;
        public string SalarysPayOrderID;
        public string SalarysPayOrderDate;
        public string EmployeesCount;
        public string MoneyAmount;
        public SalarysPayOrderMonthReport(int Year_, int MonthNO_,
         string MonthName_,
         string SalarysPayOrderID_,
        string SalarysPayOrderDate_,
         string EmployeesCount_,
         string MoneyAmount_)
        {
            Year = Year_;
            MonthNO = MonthNO_;
            MonthName = MonthName_;
            SalarysPayOrderID = SalarysPayOrderID_;
            SalarysPayOrderDate = SalarysPayOrderDate_;
            EmployeesCount = EmployeesCount_;
            MoneyAmount = MoneyAmount_;
        }

    }
}
