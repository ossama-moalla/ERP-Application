using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.Reports
{
    public class SalarysPayOrderEmployeeReport
    {
        public int EmployeeID;
        public string EmployeeName;
        public string JobState;
        public string EmployeeMentState;
        public int EmployeeStateCode;
        public string ExcpectedSalary;
        public int? PayOrderID;
        public double? PayedSalaryValue;
        public Currency PayedSalaryCurrecny;
        public double? PayedSalaryExchangeRate;
        public string Paid;
        public double? Remain;
        public double? PaysRealValue;
        public SalarysPayOrderEmployeeReport(int EmployeeID_,
         string EmployeeName_,
         string JobState_,
         string EmployeeMentState_,
         int EmployeeStateCode_,
         string ExcpectedSalary_,
         int? PayOrderID_,
         double? PayedSalaryValue_,
         Currency PayedSalaryCurrecny_,
         double? PayedSalaryExchangeRate_,
            string Paid_,
         double? Remain_,
         double? PaysRealValue_
           )
        {
            EmployeeID = EmployeeID_;
            EmployeeName = EmployeeName_;
            JobState = JobState_;
            EmployeeMentState = EmployeeMentState_;
            EmployeeStateCode = EmployeeStateCode_;
            ExcpectedSalary = ExcpectedSalary_;
            PayOrderID = PayOrderID_;
            PayedSalaryValue = PayedSalaryValue_;
            PayedSalaryCurrecny = PayedSalaryCurrecny_;
            PayedSalaryExchangeRate = PayedSalaryExchangeRate_;
            Paid = Paid_;
            Remain = Remain_;
            PaysRealValue = PaysRealValue_;
        }
    }
}
