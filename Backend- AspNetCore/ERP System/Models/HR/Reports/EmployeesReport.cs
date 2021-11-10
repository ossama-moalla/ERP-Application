using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.Reports
{
    public class EmployeesReport
    {
        
    
        
        public uint EmployeeID;
        public string EmployeeName;
        public bool Gender;
        public DateTime BirthDate;
        public string NationalID;
        public string MaritalStatusName;
        public string Mobile;
        public string Phone;
        public string EmailAddress;
        public string Address;
        public string Report;

        public string JobState;
        public string EmployeeMentState;
        public uint EmployeeStateCode;
        public EmployeesReport(uint EmployeeID_, string EmployeeName_, bool Gender_, DateTime BirthDate_, string NationalID_,
         string MaritalStatusName_, string Mobile_, string Phone_, string EmailAddress_, string Address_, string Report_, string JobState_, string EmployeeMentState_, uint EmployeeStateCode_)
        {
            EmployeeID = EmployeeID_;
            EmployeeName = EmployeeName_;
            Gender = Gender_;
            BirthDate = BirthDate_;
            NationalID = NationalID_;
            MaritalStatusName = MaritalStatusName_;
            Mobile = Mobile_;
            Phone = Phone_;
            EmailAddress = EmailAddress_;
            Address = Address_;
            Report = Report_;
            JobState = JobState_;
            EmployeeMentState = EmployeeMentState_;
            EmployeeStateCode = EmployeeStateCode_;

        }
        internal static List<EmployeesReport> Get_EmployeesReport_List_From_DataTable(System.Data.DataTable table)
        {
            try
            {
                List<EmployeesReport> list = new List<EmployeesReport>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    uint EmployeeID = Convert.ToUInt32(table.Rows[i]["EmployeeID"]);
                    string EmployeeName = table.Rows[i]["EmployeeName"].ToString();

                    bool Gender = Convert.ToBoolean(table.Rows[i]["Gender"]);
                    DateTime BirthDate = Convert.ToDateTime(table.Rows[i]["BirthDate"].ToString());
                    string NationalID = table.Rows[i]["NationalID"].ToString();
                    string MaritalStatusName = table.Rows[i]["MaritalStatusName"].ToString();
                    string Mobile = table.Rows[i]["Mobile"].ToString();
                    string Phone = table.Rows[i]["Phone"].ToString();
                    string EmailAddress = table.Rows[i]["EmailAddress"].ToString();
                    string Address = table.Rows[i]["Address"].ToString();
                    string Report = table.Rows[i]["Report"].ToString();

                    string JobState = table.Rows[i]["JobState"].ToString();
                    string EmployeeMentState = table.Rows[i]["EmployeeMentState"].ToString();
                    uint EmployeeStateCode = Convert.ToUInt32(table.Rows[i]["EmployeeStateCode"]);


                    list.Add(new EmployeesReport(EmployeeID, EmployeeName, Gender, BirthDate, NationalID, MaritalStatusName, Mobile,
        Phone, EmailAddress, Address, Report, JobState, EmployeeMentState, EmployeeStateCode));
                }
                return list;
            }
            catch (Exception ee)
            {
                throw new Exception("Get_EmployeeMent_Employee_Report_List_From_DataTable:" + "," + ee.Message);
            }
        }
        //public static void SetComboBoxFilter(ref System.Windows.Forms.ComboBox combobox)
        //{
        //    combobox.Items.Add(new ComboboxItem("الكل", 0));
        //    combobox.Items.Add(new ComboboxItem("مباشر و مسند له وظيفة", EmployeesReport.EMPLOYEE_ON_WORK_ON_EMPLOYEEMENT));
        //    combobox.Items.Add(new ComboboxItem("مباشر و غير مسند له وظيفة", EmployeesReport.EMPLOYEE_ON_WORK_NO_EMPLOYEEMENT));
        //    combobox.Items.Add(new ComboboxItem("لم يباشر العمل بعد", EmployeesReport.EMPLOYEE_NOT_START_WORK));
        //    combobox.Items.Add(new ComboboxItem("غادر العمل", EmployeesReport.EMPLOYEE_LEFT_WORK));
        //    combobox.SelectedIndex = 0;

        //}
    }
}
