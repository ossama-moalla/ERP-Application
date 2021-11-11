using ERP_System.Models.HR.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.HR_Repository.Reports
{
    public class ReportPayOrders_Repo
    {
        Application_Identity_DbContext DbContext;
        public ReportPayOrders_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        internal List<Report_PayOrders_Day_ReportDetail> Get_Report_PayOrders_Day_ReportDetail(int year, int month, int day)
        {
            throw new NotImplementedException();
        }
        internal Report_PayOrders_Month_ReportDetail Get_Report_PayOrders_Day_Report(int year, int month, int day)
        {
            throw new NotImplementedException();
        }
        internal List<Report_PayOrders_Month_ReportDetail> Get_Report_PayOrders_Month_ReportDetail(int year, int month)
        {
            throw new NotImplementedException();
        }
        internal Report_PayOrders_Year_ReportDetail Get_Report_PayOrders_Month_Report(int year, int month)
        {
            throw new NotImplementedException();
        }
        internal List<Report_PayOrders_Year_ReportDetail> Get_Report_PayOrders_Year_ReportDetail(int year)
        {
            throw new NotImplementedException();
        }
        internal Report_PayOrders_YearRange_ReportDetail Get_Report_PayOrders_Year_Report(int year)
        {
            throw new NotImplementedException();
        }
        internal List<Report_PayOrders_YearRange_ReportDetail> Get_Report_PayOrders_YearRange_ReportDetail(int min_year, int max_year)
        {
            throw new NotImplementedException();
        }
    }
}
