using ERP_System.Models.Trade.Report_Bills_Buy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Buy_Repository.Reports
{
    public class ReportBuys_Repo
    {
        Application_Identity_DbContext DbContext;
        public ReportBuys_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public List<Report_Buys_Day_ReportDetail> Get_Report_Buys_Day_ReportDetail(int year, int month, int day)
        {
            throw new NotImplementedException();
        }
        internal Report_Buys_Month_ReportDetail Get_Report_Buys_Day_Report(int year, int month, int day)
        {
            throw new NotImplementedException();
        }
        internal List<Report_Buys_Month_ReportDetail> Get_Report_Buys_Month_ReportDetail(int year, int month)
        {
            throw new NotImplementedException();
        }
        internal List<Report_Buys_Year_ReportDetail> Get_Report_Buys_Year_ReportDetail(int year)
        {
            throw new NotImplementedException();
        }
        internal Report_Buys_YearRange_ReportDetail Get_Report_Buys_Year_Report(int year)
        {
            throw new NotImplementedException();
        }
        internal List<Report_Buys_YearRange_ReportDetail> Get_Report_Buys_YearRange_ReportDetail(int min_year, int max_year)
        {
            throw new NotImplementedException();
        }
    }
}
