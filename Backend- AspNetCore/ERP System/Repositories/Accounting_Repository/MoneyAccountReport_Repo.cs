using ERP_System.Models.Accounting;
using ERP_System.Models.Accounting.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class MoneyAccountReport_Repo
    {
        private readonly IApplicationRepository<PayIN> PayIN_Repo;
        private readonly IApplicationRepository<PayOUT> PayOUT_Repo;
        private readonly IApplicationRepository<ExchangeOPR> ExchangeOPR_Repo;
        private readonly IApplicationRepository<MoneyTransFormOPR> MoneyTransFormOPR_Repo;

        public MoneyAccountReport_Repo(
             IApplicationRepository<PayIN> PayIN_Repo,
             IApplicationRepository<PayOUT> PayOUT_Repo,
             IApplicationRepository<ExchangeOPR> ExchangeOPR_Repo,
             IApplicationRepository<MoneyTransFormOPR> MoneyTransFormOPR_Repo
             )
        {
            this.PayIN_Repo = PayIN_Repo;
            this.PayOUT_Repo = PayOUT_Repo;
            this.ExchangeOPR_Repo = ExchangeOPR_Repo;
            this.MoneyTransFormOPR_Repo = MoneyTransFormOPR_Repo;
        }
        public List<MoneyAccountOperation> GetMoneyAccountOperations(int MoneyAccountId)
        {
            List<MoneyAccountOperation> list = new();
            {
                var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId).ToList();
                list.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(PayINList));
            }
            {
                var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId).ToList();
                list.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(PayOUTList));
            }
            {
                var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId).ToList();
                list.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(ExchangeOPRList));
            }
            {
                var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)).ToList();
                list.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, MoneyTransformOPRList));
            }
            return list;
        }
        public string MoneyAccountValue( int MoneyAccountId)
        {
            
            return MoneyAccountOperation.Get_Clear_MoneyValue(GetMoneyAccountOperations(MoneyAccountId));

        }
        public double MoneyAccountValueByCurrency( int MoneyAccountId, int CurrencyID)
        {
            var  list = GetMoneyAccountOperations(MoneyAccountId);
            double clearvalue = Math.Round(MoneyAccountOperation.Get_Clear_MoneyValue_ByCurrency(CurrencyID, list), 2);
            return clearvalue;

        }
        public MoneyAccount_DayReport DayReport( int MoneyAccountId, int year, int month,  int day)
        {
            var operationList = GetMoneyAccountOperations(MoneyAccountId).Where(x => x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
            List<MoneyAccount_CurrencyReport> CurrencyReportList
                = MoneyAccountOperation.Convert_MoneyAccountOperation_To_CurrencyReport(operationList);

            return new MoneyAccount_DayReport() { OperationsList = operationList, CurrencyReportList = CurrencyReportList };

        }
        public MoneyAccount_MonthReport MonthReport( int MoneyAccountId,  int year,  int month)
        {
            var operationList = GetMoneyAccountOperations(MoneyAccountId).Where(x =>  x.Date.Month == month && x.Date.Year == year).ToList();
            List<MoneyAccountReport_InDay> MoneyAccountReport_InDay_List = new();
            int max_days = DateTime.DaysInMonth(year, month);
            for (int i = 1; i <= max_days; i++)
            {
                List<MoneyAccountOperation> day_operations_IN, day_operations_OUT;
                day_operations_IN = operationList.Where(x => x.Date.Day == i && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).ToList();
                day_operations_OUT = operationList.Where(x => x.Date.Day == i && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).ToList();

                var report_in_day = new MoneyAccountReport_InDay()
                {
                    DateDayNo = i,
                    Date_day = new DateTime(year, month, i),
                    PaysIN_Count = day_operations_IN.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR).Count(),
                    PaysOUT_Count = day_operations_OUT.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR).Count(),
                    ExchangeOPR_Count = day_operations_IN.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR).Count(),
                    //exchange opr added as 2 operation (in with tartget currency and out with source currency)
                    MoneyTransform_IN_Count = day_operations_IN.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR).Count(),
                    MoneyTransform_OUT_Count = day_operations_OUT.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR).Count(),
                    MoneyIN_Value = MoneyAccountOperation.Get_MoneyIN_Value(day_operations_IN),
                    MoneyIN_Real_Value = day_operations_IN.Sum(x => x.RealValue),
                    MoneyOUT_Value = MoneyAccountOperation.Get_MoneyOUT_Value(day_operations_OUT),
                    MoneyOUT_Real_Value = day_operations_OUT.Sum(x => x.RealValue)
                };
                MoneyAccountReport_InDay_List.Add(report_in_day);

            }
            return new MoneyAccount_MonthReport()
            {
                MoneyAccountReport_InDay_List = MoneyAccountReport_InDay_List
            ,
                CurrencyReportList = MoneyAccountOperation.Convert_MoneyAccountOperation_To_CurrencyReport(operationList)
            };

        }
        public MoneyAccount_YearReport YearReport( int MoneyAccountId,  int year)
        {
            var operationList = GetMoneyAccountOperations(MoneyAccountId).Where(x => x.Date.Year == year).ToList();
            List<MoneyAccountReport_InMonth> MoneyAccountReport_InMonth_List = new();
            for (int i = 1; i <= 12; i++)
            {
                List<MoneyAccountOperation> month_operations_IN, month_operations_OUT;
                month_operations_IN = operationList.Where(x => x.Date.Month == i && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).ToList();
                month_operations_OUT = operationList.Where(x => x.Date.Month == i && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).ToList();

                var report_in_month = new MoneyAccountReport_InMonth()
                {
                    Year_Month = i,
                    Year_Month_Name = System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.GetAbbreviatedMonthName(i),
                    PaysIN_Count = month_operations_IN.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR).Count(),
                    PaysOUT_Count = month_operations_OUT.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR).Count(),
                    ExchangeOPR_Count = month_operations_IN.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR).Count(),
                    //exchange opr added as 2 operation (in with tartget currency and out with source currency)
                    MoneyTransform_IN_Count = month_operations_IN.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR).Count(),
                    MoneyTransform_OUT_Count = month_operations_OUT.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR).Count(),
                    MoneyIN_Value = MoneyAccountOperation.Get_MoneyIN_Value(month_operations_IN),
                    MoneyIN_Real_Value = month_operations_IN.Sum(x => x.RealValue),
                    MoneyOUT_Value = MoneyAccountOperation.Get_MoneyOUT_Value(month_operations_OUT),
                    MoneyOUT_Real_Value = month_operations_OUT.Sum(x => x.RealValue)
                };
                MoneyAccountReport_InMonth_List.Add(report_in_month);

            }
            return new MoneyAccount_YearReport()
            {
                MoneyAccountReport_InMonth_List = MoneyAccountReport_InMonth_List
            ,
                CurrencyReportList = MoneyAccountOperation.Convert_MoneyAccountOperation_To_CurrencyReport(operationList)
            };

        }
        public MoneyAccount_YearRangeReport YearRangeReport( int MoneyAccountId,  int year1,  int year2)
        {
            List<MoneyAccountReport_InYear> list = new();
            int minYear, maxYear;
            if (year1 > year2)
            {
                minYear = year2;
                maxYear = year1;
            }
            else
            {
                minYear = year1;
                maxYear = year2;
            }
            var operationList = GetMoneyAccountOperations(MoneyAccountId).Where(x => x.Date.Year >= minYear && x.Date.Year <= maxYear).ToList();
            List<MoneyAccountReport_InYear> MoneyAccountReport_InYear_List = new();
            for (int i = minYear; i <= maxYear; i++)
            {
                List<MoneyAccountOperation> year_operations_IN, year_operations_OUT;
                year_operations_IN = operationList.Where(x => x.Date.Year == i && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).ToList();
                year_operations_OUT = operationList.Where(x => x.Date.Year == i && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).ToList();

                var report_in_year = new MoneyAccountReport_InYear()
                {
                    Year = i,
                    PaysIN_Count = year_operations_IN.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR).Count(),
                    PaysOUT_Count = year_operations_OUT.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR).Count(),
                    ExchangeOPR_Count = year_operations_IN.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR).Count(),
                    //exchange opr added as 2 operation (in with tartget currency and out with source currency)
                    MoneyTransform_IN_Count = year_operations_IN.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR).Count(),
                    MoneyTransform_OUT_Count = year_operations_OUT.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR).Count(),
                    MoneyIN_Value = MoneyAccountOperation.Get_MoneyIN_Value(year_operations_IN),
                    MoneyIN_Real_Value = year_operations_IN.Sum(x => x.RealValue),
                    MoneyOUT_Value = MoneyAccountOperation.Get_MoneyOUT_Value(year_operations_OUT),
                    MoneyOUT_Real_Value = year_operations_OUT.Sum(x => x.RealValue)
                };
                MoneyAccountReport_InYear_List.Add(report_in_year);

            }
            return new MoneyAccount_YearRangeReport()
            {
                MoneyAccountReport_InYear_List = MoneyAccountReport_InYear_List
            ,
                CurrencyReportList = MoneyAccountOperation.Convert_MoneyAccountOperation_To_CurrencyReport(operationList)
            };

        }
    }
}
