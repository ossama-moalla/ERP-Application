using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.Reports
{
    public class EmployeeMent_Employee_Report
    {
        public uint LevelID;
        public string LevelName;
        public uint EmployeeMentID;
        public string EmployeeMentName;
        public string PartName;
        public uint? EmployeeID;
        public string EmployeeName;
        public uint? JobstartID;
        public DateTime? JobStartDate;
        public uint? AssignID;
        public DateTime? AssignDate;
        public EmployeeMent_Employee_Report(uint LevelID_, string LevelName_, uint EmployeeMentID_, string EmployeeMentName_, string PartName_,
         uint? EmployeeID_, string EmployeeName_, uint? JobstartID_, DateTime? JobStartDate_, uint? AssignID_, DateTime? AssignDate_)
        {
            LevelID = LevelID_;
            LevelName = LevelName_;
            EmployeeMentID = EmployeeMentID_;
            EmployeeMentName = EmployeeMentName_;
            PartName = PartName_;
            EmployeeID = EmployeeID_;
            EmployeeName = EmployeeName_;
            JobstartID = JobstartID_;
            JobStartDate = JobStartDate_;
            AssignID = AssignID_;
            AssignDate = AssignDate_;
        }
        internal static List<EmployeeMent_Employee_Report> Get_EmployeeMent_Employee_Report_List_From_DataTable(System.Data.DataTable table)
        {
            try
            {
                List<EmployeeMent_Employee_Report> list = new List<EmployeeMent_Employee_Report>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    uint LevelID = Convert.ToUInt32(table.Rows[i]["LevelID"]);
                    string LevelName = table.Rows[i]["LevelName"].ToString();

                    uint EmployeeMentID = Convert.ToUInt32(table.Rows[i]["EmployeeMentID"]);
                    string EmployeeMentName = table.Rows[i]["EmployeeMentName"].ToString();
                    string PartName = table.Rows[i]["PartName"].ToString();
                    uint? EmployeeID;

                    if (table.Rows[i]["EmployeeID"] != DBNull.Value)
                        EmployeeID = Convert.ToUInt32(table.Rows[i]["EmployeeID"]);
                    else
                        EmployeeID = null;
                    string EmployeeName;

                    EmployeeName = table.Rows[i]["EmployeeName"].ToString();
                    uint? JobstartID;

                    if (table.Rows[i]["JobstartID"] != DBNull.Value)

                        JobstartID = Convert.ToUInt32(table.Rows[i]["JobstartID"]);
                    else
                        JobstartID = null;
                    DateTime? JobStartDate;

                    if (table.Rows[i]["JobStartDate"] != DBNull.Value)
                        JobStartDate = Convert.ToDateTime(table.Rows[i]["JobStartDate"]);
                    else
                        JobStartDate = null;

                    uint? AssignID;
                    if (table.Rows[i]["AssignID"] != DBNull.Value)
                        AssignID = Convert.ToUInt32(table.Rows[i]["AssignID"]);

                    else

                        AssignID = null;

                    DateTime? AssignDate;

                    if (table.Rows[i]["AssignDate"] != DBNull.Value)

                        AssignDate = Convert.ToDateTime(table.Rows[i]["AssignDate"]);
                    else
                        AssignDate = null;

                    list.Add(new EmployeeMent_Employee_Report(LevelID, LevelName,
         EmployeeMentID, EmployeeMentName, PartName, EmployeeID, EmployeeName, JobstartID, JobStartDate, AssignID, AssignDate));
                }
                return list;
            }
            catch (Exception ee)
            {
                throw new Exception("Get_EmployeeMent_Employee_Report_List_From_DataTable:" + "," + ee.Message);
            }
        }

    }
}
