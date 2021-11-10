using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR
{
    public class Document
    {
        public enum JobState : ushort
        {
            EMPLOYEE_NOT_START_WORK = 1,
            EMPLOYEE_LEFT_WORK = 2,
            EMPLOYEE_ON_WORK_NO_EMPLOYEEMENT = 3,
            EMPLOYEE_ON_WORK_ON_EMPLOYEEMENT = 4
        }
        public enum DocumentType_Enum : ushort
        {
             JOBSTART_DOCUMENT = 1,
             ENDJOBSTART_DOCUMENT = 2,
             ASSIGN_DOCUMENT = 3,
             ENDASSIGN_DOCUMENT = 4

        }


    public uint DocumentID;
        public DateTime DocumentDate;
        public Employee _Employee;
        public ushort DocumentType;
        public DateTime ExecuteDate;
        public Document TargetDocument;
        public EmployeeMent _EmployeeMent;
        public string Details;
        public Document(uint DocumentID_, DateTime DocumentDate_, Employee Employee_,
            ushort DocumentType_, DateTime ExecuteDate_, Document TargetDocument_, EmployeeMent EmployeeMent_, string Details_)
        {
            DocumentID = DocumentID_;
            DocumentDate = DocumentDate_;
            _Employee = Employee_;
            DocumentType = DocumentType_;
            ExecuteDate = ExecuteDate_;
            TargetDocument = TargetDocument_;
            _EmployeeMent = EmployeeMent_;
            Details = Details_;
        }
        public string GetDocumentDesc()
        {
            switch (this.DocumentType)
            {
                case (ushort) DocumentType_Enum.JOBSTART_DOCUMENT:
                    return "أمر مباشرة";
                case (ushort)DocumentType_Enum.ENDJOBSTART_DOCUMENT:
                    return "أمر انهاء مباشرة";

                case (ushort)DocumentType_Enum.ASSIGN_DOCUMENT:

                    return "أمر تكليف وظيفة";
                case (ushort)DocumentType_Enum.ENDASSIGN_DOCUMENT:
                    return "أمر انهاء تكليف";
                default:
                    return "مستند غير معروف";

            }
        }
    }
}
