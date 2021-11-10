using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR
{
    public class EmployeeCertificate
    {
        public Employee _Employee;
        public string CertificatesDesc;
        public string University;
        public DateTime StartDate;
        public DateTime EndDate;
        public string Notes;
        public EmployeeCertificate(Employee Employee_, string CertificatesDesc_
           , string University_, DateTime StartDate_, DateTime EndDate_, string Notes_)
        {
            _Employee = Employee_;
            CertificatesDesc = CertificatesDesc_;
            University = University_;
            StartDate = StartDate_;
            EndDate = EndDate_;
            Notes = Notes_;
        }
    }
}
