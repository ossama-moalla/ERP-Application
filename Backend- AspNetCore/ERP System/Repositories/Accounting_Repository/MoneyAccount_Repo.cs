using ERP_System.Models.Accounting;
using ERP_System.Models.Accounting.Reports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class MoneyAccount_Repo : IApplicationRepository<MoneyAccount>
        ,IReportByDateTypeRepository<MoneyAccountOperation, MoneyAccount_DayReport, MoneyAccount_MonthReport,MoneyAccount_YearReport
            , MoneyAccount_YearRangeReport>
    {
        private readonly Application_Identity_DbContext DbContext;
        private readonly IApplicationRepository<PayIN> PayIN_Repo;
        private readonly IApplicationRepository<PayOUT> PayOUT_Repo;
        private readonly IApplicationRepository<ExchangeOPR> ExchangeOPR_Repo;
        private readonly IApplicationRepository<MoneyTransFormOPR> MoneyTransFormOPR_Repo;

        public MoneyAccount_Repo(Application_Identity_DbContext DbContext_, IApplicationRepository<PayIN> PayIN_Repo,
            IApplicationRepository<PayOUT> PayOUT_Repo, IApplicationRepository<ExchangeOPR> ExchangeOPR_Repo
            , IApplicationRepository<MoneyTransFormOPR> MoneyTransFormOPR_Repo)
        {
            DbContext = DbContext_;
            this.PayIN_Repo = PayIN_Repo;
            this.PayOUT_Repo = PayOUT_Repo;
            this.ExchangeOPR_Repo = ExchangeOPR_Repo;
            this.MoneyTransFormOPR_Repo = MoneyTransFormOPR_Repo;
        }
        public MoneyAccount Add(MoneyAccount entity)
        {
            DbContext.Accounting_MoneyAccount.Add(entity);
            DbContext.SaveChanges();
            return entity;
            
        }

        public void Delete(int id)
        {
            var moneyaccount = GetByID(id);
            if (moneyaccount == null) LocalException.ThrowNotFound("Delete Failed! SellType with Id:" + id + " Not Exists");
            DbContext.Accounting_MoneyAccount.Remove(moneyaccount);
            DbContext.SaveChanges();
            
        }

        public void Update(MoneyAccount entity)
        {
            var moneyaccount = GetByID(entity.Id);
            if (moneyaccount == null) LocalException.ThrowNotFound("Update Failed! MoneyAccount with Id:" + entity.Id + " Not Exists");
            moneyaccount.Name = entity.Name;
            DbContext.SaveChanges();
            
        }

        public MoneyAccount GetByID(int id)
        {
            var moneyaccount= DbContext.Accounting_MoneyAccount.SingleOrDefault(x => x.Id == id);
            if(moneyaccount==null) return  null;
            DbContext.Entry(moneyaccount).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            var OperationList = new List<MoneyAccountOperation>();
            {
                var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == id).ToList();
                foreach (var payin in PayINList)
                {
                    string details = string.Empty;
                    if (payin.OperationId != null && payin.OperationType != null)
                    {
                        details = "belong to :" + Models.Trade.Operation.GetOperationName(Convert.ToInt32(payin.OperationType))
                            + ",with ID:" + payin.OperationId;
                    }
                    else details = "not belong to any bill";
                    MoneyAccountOperation moneyaccountoperation = new()
                    {
                        Id = payin.Id,
                        Date = payin.Date,
                        MoneyAccountId = payin.MoneyAccountId,
                        OprType = MoneyAccountOperation.TYPE_PAY_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_IN,
                        TradeOperationId = payin.OperationId,
                        TradeOperationType = payin.OperationType,
                        Value = payin.Value,
                        CurrencyID = payin.Currency.Id,
                        CurrencyName = payin.Currency.Name,
                        CurrencySymbol = payin.Currency.Symbol,
                        ExchangeRate = payin.ExchangeRate,
                        RealValue = Math.Round((payin.Value / payin.ExchangeRate), 3),
                        Details = details
                    };
                    OperationList.Add(moneyaccountoperation);
                }
                {
                    var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == id).ToList();
                    foreach (var payout in PayOUTList)
                    {
                        string details = string.Empty;
                        if (payout.OperationId != null && payout.OperationType != null)
                        {
                            details = "belong to :" + Models.Trade.Operation.GetOperationName(Convert.ToInt32(payout.OperationType))
                                + ",with ID:" + payout.OperationId;
                        }
                        else details = "not belong to any bill or payprder";
                        var moneyaccountoperation = new MoneyAccountOperation()
                        {
                            Id = payout.Id,
                            Date = payout.Date,
                            MoneyAccountId = payout.MoneyAccountId,
                            OprType = MoneyAccountOperation.TYPE_PAY_OPR,
                            OprDirection = MoneyAccountOperation.DIRECTION_OUT,
                            TradeOperationId = payout.OperationId,
                            TradeOperationType = payout.OperationType,
                            Value = payout.Value,
                            CurrencyID = payout.Currency.Id,
                            CurrencyName = payout.Currency.Name,
                            CurrencySymbol = payout.Currency.Symbol,
                            ExchangeRate = payout.ExchangeRate,
                            RealValue = Math.Round((payout.Value / payout.ExchangeRate), 3),
                            Details = details,

                        };
                        OperationList.Add(moneyaccountoperation);
                    }
                    {
                        var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == id).ToList();
                        foreach (var exchangeopr in ExchangeOPRList)
                        {
                            var moneyaccountoperationOUT = new MoneyAccountOperation()
                            {
                                Id = exchangeopr.Id,
                                Date = exchangeopr.Date,
                                MoneyAccountId = exchangeopr.MoneyAccountId,
                                OprType = MoneyAccountOperation.TYPE_EXCHANGE_OPR,
                                OprDirection = MoneyAccountOperation.DIRECTION_OUT,
                                TradeOperationId = null,
                                TradeOperationType = null,
                                Value = exchangeopr.OutMoneyValue,
                                CurrencyID = exchangeopr.SourceCurrency.Id,
                                CurrencyName = exchangeopr.SourceCurrency.Name,
                                CurrencySymbol = exchangeopr.SourceCurrency.Symbol,
                                ExchangeRate = exchangeopr.SourceExchangeRate,
                                RealValue = Math.Round((exchangeopr.OutMoneyValue / exchangeopr.SourceExchangeRate), 3),
                                Details = "Exchange from :" + exchangeopr.SourceCurrency.Name + " to:" + exchangeopr.TargetCurrency.Name


                            };
                            OperationList.Add(moneyaccountoperationOUT);
                            var moneyaccountoperationIN = new MoneyAccountOperation()
                            {
                                Id = exchangeopr.Id,
                                Date = exchangeopr.Date,
                                MoneyAccountId = exchangeopr.MoneyAccountId,
                                OprType = MoneyAccountOperation.TYPE_EXCHANGE_OPR,
                                OprDirection = MoneyAccountOperation.DIRECTION_IN,
                                TradeOperationId = null,
                                TradeOperationType = null,
                                Value = Math.Round(exchangeopr.OutMoneyValue
                                    * (exchangeopr.TargetExchangeRate / exchangeopr.SourceExchangeRate), 3),
                                CurrencyID = exchangeopr.TargetCurrency.Id,
                                CurrencyName = exchangeopr.TargetCurrency.Name,
                                CurrencySymbol = exchangeopr.TargetCurrency.Symbol,
                                ExchangeRate = exchangeopr.TargetExchangeRate,
                                RealValue = Math.Round((exchangeopr.OutMoneyValue / exchangeopr.SourceExchangeRate), 3),
                                Details = "Exchange from :" + exchangeopr.SourceCurrency.Name + " to:" + exchangeopr.TargetCurrency.Name

                            };
                            OperationList.Add(moneyaccountoperationIN);
                        }
                        {
                            
                            var MoneyTransFormOPRList = MoneyTransFormOPR_Repo.List().Where(x => x.SourceMoneyAccountId == id
                            ||x.TargetMoneyAccountId==id).ToList();
                            {
                                var MoneyTransFormOPRList_IN = MoneyTransFormOPRList.Where(x => x.TargetMoneyAccountId == id).ToList();
                                foreach (var moneytransformopr in MoneyTransFormOPRList_IN)
                                {
                                    var moneyaccountoperation = new MoneyAccountOperation()
                                    {
                                        Id = moneytransformopr.Id,
                                        Date = moneytransformopr.Date,
                                        MoneyAccountId = moneytransformopr.TargetMoneyAccountId,
                                        OprType = MoneyAccountOperation.TYPE_MoneyTransform_OPR,
                                        OprDirection = MoneyAccountOperation.DIRECTION_IN,
                                        TradeOperationId = null,
                                        TradeOperationType = null,
                                        Value = moneytransformopr.Value,
                                        CurrencyID = moneytransformopr.Currency.Id,
                                        CurrencyName = moneytransformopr.Currency.Name,
                                        CurrencySymbol = moneytransformopr.Currency.Symbol,
                                        ExchangeRate = moneytransformopr.ExchangeRate,
                                        RealValue = Math.Round((moneytransformopr.Value / moneytransformopr.ExchangeRate), 3),
                                        Details = "transformed from :" + moneytransformopr.SourceMoneyAccount.Name,

                                    };
                                    OperationList.Add(moneyaccountoperation);
                                }
                            }
                            {
                                var MoneyTransFormOPRList_OUT = MoneyTransFormOPRList.Where(x => x.SourceMoneyAccountId == id).ToList();
                                foreach (var moneytransformopr in MoneyTransFormOPRList_OUT)
                                {
                                    var moneyaccountoperation = new MoneyAccountOperation()
                                    {
                                        Id = moneytransformopr.Id,
                                        Date = moneytransformopr.Date,
                                        MoneyAccountId = moneytransformopr.SourceMoneyAccountId,
                                        OprType = MoneyAccountOperation.TYPE_MoneyTransform_OPR,
                                        OprDirection = MoneyAccountOperation.DIRECTION_OUT,
                                        TradeOperationId = null,
                                        TradeOperationType = null,
                                        Value = moneytransformopr.Value,
                                        CurrencyID = moneytransformopr.Currency.Id,
                                        CurrencyName = moneytransformopr.Currency.Name,
                                        CurrencySymbol = moneytransformopr.Currency.Symbol,
                                        ExchangeRate = moneytransformopr.ExchangeRate,
                                        RealValue = Math.Round((moneytransformopr.Value / moneytransformopr.ExchangeRate), 3),
                                        Details = "transformed to :" + moneytransformopr.TargetMoneyAccount.Name,

                                    };
                                    OperationList.Add(moneyaccountoperation);
                                }
                            }
                            
                        }
                    }
                }
                moneyaccount.OperationList = OperationList;
                return moneyaccount;
            }
        }

        public IList<MoneyAccount> List()
        {
            return DbContext.Accounting_MoneyAccount.ToList();
        }
        public MoneyAccount_DayReport DayReport(List<MoneyAccountOperation> Operations, int year, int month, int day)
        {
            var operationList = Operations.Where(x => x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
            List<MoneyAccount_CurrencyReport> CurrencyReportList
                = MoneyAccountOperation.Convert_MoneyAccountOperation_To_CurrencyReport(operationList);

            return new MoneyAccount_DayReport()
            {
                Year = year,
                Month = month,
                Day = day,
                OperationsList = operationList,
                CurrencyReportList = CurrencyReportList
            };
        }

        public MoneyAccount_MonthReport MonthReport(List<MoneyAccountOperation> Operations, int year, int month)
        {
            var operationList = Operations.Where(x => x.Date.Month == month && x.Date.Year == year).ToList();
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
                    MoneyIN_Value = MoneyAccountOperation.Calculate_Operations_MoneyIN_Value(day_operations_IN),
                    MoneyIN_Real_Value = day_operations_IN.Sum(x => x.RealValue),
                    MoneyOUT_Value = MoneyAccountOperation.Calculate_Operations_MoneyOUT_Value(day_operations_OUT),
                    MoneyOUT_Real_Value = day_operations_OUT.Sum(x => x.RealValue)
                };
                MoneyAccountReport_InDay_List.Add(report_in_day);

            }
            return new MoneyAccount_MonthReport()
            {
                Year = year,
                Month = month,
                MoneyAccountReport_InDay_List = MoneyAccountReport_InDay_List,
                CurrencyReportList = MoneyAccountOperation.Convert_MoneyAccountOperation_To_CurrencyReport(operationList)
            };

        }

        public MoneyAccount_YearReport YearReport(List<MoneyAccountOperation> Operations, int year)
        {
            var operationList = Operations.Where(x => x.Date.Year == year).ToList();
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
                    MoneyIN_Value = MoneyAccountOperation.Calculate_Operations_MoneyIN_Value(month_operations_IN),
                    MoneyIN_Real_Value = month_operations_IN.Sum(x => x.RealValue),
                    MoneyOUT_Value = MoneyAccountOperation.Calculate_Operations_MoneyOUT_Value(month_operations_OUT),
                    MoneyOUT_Real_Value = month_operations_OUT.Sum(x => x.RealValue)
                };
                MoneyAccountReport_InMonth_List.Add(report_in_month);

            }
            return new MoneyAccount_YearReport()
            {
                Year = year,
                MoneyAccountReport_InMonth_List = MoneyAccountReport_InMonth_List,
                CurrencyReportList = MoneyAccountOperation.Convert_MoneyAccountOperation_To_CurrencyReport(operationList)
            };
        }

        public MoneyAccount_YearRangeReport YearRangeReport(List<MoneyAccountOperation> Operations, int year1, int year2)
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
            var operationList = Operations.Where(x => x.Date.Year >= minYear && x.Date.Year <= maxYear).ToList();
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
                    MoneyIN_Value = MoneyAccountOperation.Calculate_Operations_MoneyIN_Value(year_operations_IN),
                    MoneyIN_Real_Value = year_operations_IN.Sum(x => x.RealValue),
                    MoneyOUT_Value = MoneyAccountOperation.Calculate_Operations_MoneyOUT_Value(year_operations_OUT),
                    MoneyOUT_Real_Value = year_operations_OUT.Sum(x => x.RealValue)
                };
                MoneyAccountReport_InYear_List.Add(report_in_year);

            }
            return new MoneyAccount_YearRangeReport()
            {
                MinYear = minYear,
                MaxYear = maxYear,
                MoneyAccountReport_InYear_List = MoneyAccountReport_InYear_List,
                CurrencyReportList = MoneyAccountOperation.Convert_MoneyAccountOperation_To_CurrencyReport(operationList)
            };
        }
    }
}
