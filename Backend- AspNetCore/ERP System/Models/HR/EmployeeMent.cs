using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR
{
    public class EmployeeMent
    {
        public uint EmployeeMentID;
        public string EmployeeMentName;
        public DateTime CreateDate;
        public EmployeeMentLevel Level;
        public Department _Department;
        public EmployeeMent(uint EmployeeMentID_, string EmployeeMentName_, DateTime CreateDate_, EmployeeMentLevel Level_, Department Department_)
        {
            EmployeeMentID = EmployeeMentID_;
            EmployeeMentName = EmployeeMentName_;
            CreateDate = CreateDate_;
            Level = Level_;
            _Department = Department_;
        }
    }
}
