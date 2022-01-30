using ERP_System.Models.Accounting;
using ERP_System.Models.Accounting.Reports;
using ERP_System.Models.Trade;
using ERP_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Controllers.Accounting
{
    [Route("Accounting/[controller]")]
    [ApiController]
    public class MoneyAccountReportController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IApplicationRepository<PayIN> PayIN_Repo;
        private readonly IApplicationRepository<PayOUT> PayOUT_Repo;
        private readonly IApplicationRepository<ExchangeOPR> ExchangeOPR_Repo;
        private readonly IApplicationRepository<MoneyTransFormOPR> MoneyTransFormOPR_Repo;

        public MoneyAccountReportController(ILogger<MoneyAccountReportController> logger,
             IApplicationRepository<PayIN> PayIN_Repo,
             IApplicationRepository<PayOUT> PayOUT_Repo,
             IApplicationRepository<ExchangeOPR> ExchangeOPR_Repo,
             IApplicationRepository<MoneyTransFormOPR> MoneyTransFormOPR_Repo
             )
        {
            this.logger = logger;
            this.PayIN_Repo = PayIN_Repo;
            this.PayOUT_Repo = PayOUT_Repo;
            this.ExchangeOPR_Repo = ExchangeOPR_Repo;
            this.MoneyTransFormOPR_Repo = MoneyTransFormOPR_Repo;
        }
        [HttpGet("moneyaccount_value")]
        public ActionResult<string> MoneyAccountValue([FromQuery] int MoneyAccountId)
        {
            try
            {
                List<MoneyAccountOperation> list = new();
                {
                    var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId).ToList();
                    list.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(PayINList));
                }
                {
                    var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId ).ToList();
                    list.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(PayOUTList));
                }
                {
                    var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId ).ToList();
                    list.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(ExchangeOPRList));
                }
                {
                    var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)).ToList();
                    list.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, MoneyTransformOPRList));
                }
                return Ok(MoneyAccountOperation.Get_Clear_MoneyValue(list));

            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:MoneyAccountValue,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("day_report")]
        public ActionResult<MoneyAccount_DayReport> DayReport([FromQuery] int MoneyAccountId, [FromQuery] int year,[FromQuery] int month,[FromQuery]int day)
        {
            try
            {
                List<MoneyAccountOperation> operationList = new();

                {
                    var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(PayINList));
                }
                {
                    var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(PayOUTList));
                }
                {
                    var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(ExchangeOPRList));
                }
                {
                    var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)
                                    && x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, MoneyTransformOPRList));

                }

                List<MoneyAccount_CurrencyReport> CurrencyReportList 
                    = MoneyAccountOperation.Convert_MoneyAccountOperation_To_CurrencyReport(operationList);

                return Ok(new MoneyAccount_DayReport() { OperationsList=operationList,CurrencyReportList=CurrencyReportList});
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:DayOperation,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("month_report")]
        public ActionResult<MoneyAccount_MonthReport> MonthReport([FromQuery] int MoneyAccountId, [FromQuery] int year, [FromQuery] int month)
        {
            try
            {
                List<MoneyAccountOperation> operationList = new ();

                {
                    var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Month == month && x.Date.Year == year).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(PayINList));
                }
                {
                    var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Month == month && x.Date.Year == year).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(PayOUTList));
                }
                {
                    var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Month == month && x.Date.Year == year).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(ExchangeOPRList));
                }
                {
                    var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)
                                     && x.Date.Month == month && x.Date.Year == year).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, MoneyTransformOPRList));
                }

                List<MoneyAccountReport_InDay> MoneyAccountReport_InDay_List = new();
                int max_days = DateTime.DaysInMonth(year, month);
                for(int i = 1; i <= max_days; i++)
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
                return Ok(new MoneyAccount_MonthReport() { MoneyAccountReport_InDay_List=MoneyAccountReport_InDay_List
                ,CurrencyReportList=MoneyAccountOperation.Convert_MoneyAccountOperation_To_CurrencyReport(operationList)});
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:MonthReport,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("year_report")]
        public ActionResult<MoneyAccount_YearReport> YearReport([FromQuery] int MoneyAccountId,[FromQuery] int year)
        {
            try
            {
                List<MoneyAccountOperation> operationList = new();

                {
                    var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Year == year).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(PayINList));
                }
                {
                    var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Year == year).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(PayOUTList));
                }
                {
                    var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Year == year).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(ExchangeOPRList));
                }
                {
                    var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)
                                     && x.Date.Year == year).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, MoneyTransformOPRList));
                }

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
                return Ok(new MoneyAccount_YearReport()
                {
                    MoneyAccountReport_InMonth_List = MoneyAccountReport_InMonth_List
                ,
                    CurrencyReportList = MoneyAccountOperation.Convert_MoneyAccountOperation_To_CurrencyReport(operationList)
                });
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:YearReport,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("year_range_report")]
        public ActionResult<MoneyAccount_YearRangeReport> YearRangeReport([FromQuery] int MoneyAccountId, [FromQuery] int year1, [FromQuery] int year2)
        {
            try
            {

                List<MoneyAccountReport_InYear> list = new ();
                int minYear, maxYear;
                if(year1>year2)
                {
                    minYear = year2;
                    maxYear = year1;
                }
                else
                {
                    minYear = year1;
                    maxYear = year2;
                }
                List<MoneyAccountOperation> operationList = new();

                {
                    var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId
                    && x.Date.Year >= minYear && x.Date.Year <= maxYear).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(PayINList));
                }
                {
                    var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId
                    && x.Date.Year >= minYear && x.Date.Year <= maxYear).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(PayOUTList));
                }
                {
                    var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId
                    && x.Date.Year >= minYear && x.Date.Year <= maxYear).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(ExchangeOPRList));
                }
                {
                    var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)
                                     && x.Date.Year >= minYear && x.Date.Year <= maxYear).ToList();
                    operationList.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, MoneyTransformOPRList));
                }

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
                return Ok(new MoneyAccount_YearRangeReport()
                {
                    MoneyAccountReport_InYear_List = MoneyAccountReport_InYear_List
                ,
                    CurrencyReportList = MoneyAccountOperation.Convert_MoneyAccountOperation_To_CurrencyReport(operationList)
                });
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:YearRangeReport,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
