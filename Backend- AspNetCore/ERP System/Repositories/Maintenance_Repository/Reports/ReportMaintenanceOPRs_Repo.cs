using ERP_System.Models.Maintenance.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Maintenance_Repository.Reports
{
    public class ReportMaintenanceOPRs_Repo
    {
        Application_Identity_DbContext DbContext;
        public ReportMaintenanceOPRs_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        internal List<Report_MaintenanceOPRs_Day_ReportDetail> Get_Report_MaintenanceOPRs_Day_ReportDetail(int year, int month, int day)
        {
            throw new NotImplementedException();
        }
        internal Report_MaintenanceOPRs_Month_ReportDetail Get_Report_MaintenanceOPRs_Day_Report(int year, int month, int day)
        {
            throw new NotImplementedException();
        }
        internal List<Report_MaintenanceOPRs_Month_ReportDetail> Get_Report_MaintenanceOPRs_Month_ReportDetail(int year, int month)
        {
            throw new NotImplementedException();
        }
        internal Report_MaintenanceOPRs_Year_ReportDetail Get_Report_MaintenanceOPRs_Month_Report(int year, int month)
        {
            throw new NotImplementedException();
        }
        internal List<Report_MaintenanceOPRs_Year_ReportDetail> Get_Report_MaintenanceOPRs_Year_ReportDetail(int year)
        {
            throw new NotImplementedException();
        }
        internal Report_MaintenanceOPRs_YearRange_ReportDetail Get_Report_MaintenanceOPRs_Year_Report(int year)
        {
            throw new NotImplementedException();
        }
        internal List<Report_MaintenanceOPRs_YearRange_ReportDetail> Get_Report_MaintenanceOPRs_YearRange_ReportDetail(int min_year, int max_year)
        {
            throw new NotImplementedException();
        }
    }
}
