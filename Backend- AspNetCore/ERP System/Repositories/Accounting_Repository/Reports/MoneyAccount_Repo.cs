using ERP_System.Models.Accounting;
using ERP_System.Models.Accounting.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository.Reports
{
    public class MoneyAccount_Repo
    {
        Application_Identity_DbContext DbContext;
        public MoneyAccount_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public string GetAccountMoneyOverAll(MoneyAccount moneyAccount)
        {
            throw new  NotImplementedException();
        }
        internal List<PayCurrencyReport> GetPayReport_InDay(MoneyAccount moneyAccount, int year, int month, int day)
        {
            throw new NotImplementedException();
        }
        internal List<PayCurrencyReport> GetPayReport_InMonth(MoneyAccount moneyAccount, int year, int month)
        {
            throw new NotImplementedException();
        }
        internal List<PayCurrencyReport> GetPayReport_INYear(MoneyAccount moneyAccount, int year)
        {
            throw new NotImplementedException();
        }
        internal List<PayCurrencyReport> GetPayReport_betweenTwoYears(MoneyAccount moneyAccount, int year1, int year2)
        {
            throw new NotImplementedException();
        }
        internal List<AccountOprReportDetail> GetAccountOprReport_Details_InDay(MoneyAccount moneyAccount, int year, int month, int day)
        {
            throw new NotImplementedException();
        }
        internal List<AccountOprDayReportDetail> GetAccountOprReport_Details_InMonth(MoneyAccount moneyAccount, int year, int month)
        {
            throw new NotImplementedException();
        }
        internal List<AccountOprMonthReportDetail> GetAccountOprReport_Details_InYear(MoneyAccount moneyAccount, int year)
        {
            throw new NotImplementedException();
        }
        internal List<AccountOprYearReportDetail> GetAccountOprReport_Details_InYearRange(MoneyAccount moneyAccount, int year1, int year2)
        {
            throw new NotImplementedException();

        }
    }
}
