using ERP_System.Models.Trade.Report_Bills_Sell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Sell_Repository.Reports
{
    public class ReportSells_Repo
    {
        Application_Identity_DbContext DbContext;
        public ReportSells_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        internal List<Report_Sells_Day_ReportDetail> Get_Report_Sells_Day_ReportDetail(int year, int month, int day)
        {
            throw new NotImplementedException();
        }
        internal Report_Sells_Month_ReportDetail Get_Report_Sells_Day_Report(int year, int month, int day)
        {
            throw new NotImplementedException();
        }
        internal List<Report_Sells_Month_ReportDetail> Get_Report_Sells_Month_ReportDetail(int year, int month)
        {
            throw new NotImplementedException();
        }
        internal Report_Sells_Year_ReportDetail Get_Report_Sells_Month_Report(int year, int month)
        {
            throw new NotImplementedException();
        }
        internal List<Report_Sells_Year_ReportDetail> Get_Report_Sells_Year_ReportDetail(int year)
        {
            throw new NotImplementedException();
        }
        internal Report_Sells_YearRange_ReportDetail Get_Report_Sells_Year_Report(int year)
        {
            throw new NotImplementedException();
        }
        internal List<Report_Sells_YearRange_ReportDetail> Get_Report_Sells_YearRange_ReportDetail(int min_year, int max_year)
        {
            throw new NotImplementedException();
        }
    }
}
