using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR
{
    public class EmployeeQualification
    {
        public Employee _Employee;
        public string QualificationDesc;
        public DateTime StartDate;
        public DateTime EndDate;
        public string Notes;
        public EmployeeQualification(Employee Employee_, string QualificationDesc_,
             DateTime StartDate_, DateTime EndDate_, string Notes_)
        {
            _Employee = Employee_;
            QualificationDesc = QualificationDesc_;
            StartDate = StartDate_;
            EndDate = EndDate_;
            Notes = Notes_;
        }
    }
}
