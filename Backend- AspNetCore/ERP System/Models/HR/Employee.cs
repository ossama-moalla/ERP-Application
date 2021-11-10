using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR
{
    public class Employee
    {
        public enum EmployeeGender : ushort
        {
            Male = 0,
            Female = 1
        }
        public enum MaritalStatus : uint
        {
             SINGLE = 0,
             MARRIED = 1,
             divorce = 2,
             Widowed = 3

        }

        public uint EmployeeID;
        public string EmployeeName;
        public bool Gender;
        public DateTime BirthDate;
        public string NationalID;
        public MaritalStatus _MaritalStatus;
        public string Mobile;
        public string Phone;
        public string EmailAddress;
        public string Address;
        public string Report;
        public Currency SalaryCurrency;
        public Employee(uint EmployeeID_, string EmployeeName_, bool Gender_, DateTime BirthDate_
            , string NationalID_, MaritalStatus MaritalStatus_
            , string Mobile_, string Phone_, string EmailAddress_, string Address_, string Report_, Currency SalaryCurrency_)
        {
            EmployeeID = EmployeeID_;
            EmployeeName = EmployeeName_;
            BirthDate = BirthDate_;
            NationalID = NationalID_;
            _MaritalStatus = MaritalStatus_;
            Gender = Gender_;
            Mobile = Mobile_;
            Phone = Phone_;
            EmailAddress = EmailAddress_;
            Address = Address_;
            Report = Report_;
            SalaryCurrency = SalaryCurrency_;
        }

        public static string Get_MaritalStatus_BY_ID(ushort code)
        {
            switch (code)
            {
                case (ushort)MaritalStatus.SINGLE:
                    return "عازب";
                case (ushort)MaritalStatus.MARRIED:
                    return  "متزوج";
                case (ushort)MaritalStatus.divorce:
                    return  "مطلق";
                case (ushort)MaritalStatus.Widowed:
                    return  "أرمل";
                default:
                    return  "غير محدد";
            }
        }
        public static List<string> Get_MaritalStatus_List()
        {
            List<string> list = new List<string>();
            list.Add( "عازب");
            list.Add( "متزوج");
            list.Add( "مطلق");
            list.Add( "أرمل");
            return list;
        }
    }
    
}
