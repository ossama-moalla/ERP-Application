using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR
{
    public class SalaryClause
    {
        public enum Clause_Type:ushort
        {
            Due=0,//استحقاق
            Deducation = 1//استقطاع
        }
        
        /// <summary>
        /// ////
        /// </summary>
        public Employee _Employee;
        public int SalaryClauseID;
        public DateTime CreateDate;
        public string SalaryClauseDesc;
        public bool ClauseType;
        public DateTime ExecuteDate;
        public int? MonthsCount;
        public double Value;
        public string Notes;
        public SalaryClause(Employee Employee_, int SalaryClauseID_, DateTime CreateDate_, string SalaryClauseDesc_,
            bool ClauseType_, DateTime ExecuteDate_, int? MonthsCount_, double Value_, string Notes_)
        {
            _Employee = Employee_;
            SalaryClauseID = SalaryClauseID_;
            CreateDate = CreateDate_;
            SalaryClauseDesc = SalaryClauseDesc_;
            ClauseType = ClauseType_;
            ExecuteDate = ExecuteDate_;
            MonthsCount = MonthsCount_;
            Value = Value_;
            Notes = Notes_;
        }
    }
}
