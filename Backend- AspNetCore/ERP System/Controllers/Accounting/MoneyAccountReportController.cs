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
    [Route("api/[controller]")]
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

        [HttpGet("day_operations")]
        public ActionResult<IEnumerable<MoneyAccountOperation>> DayOperations([FromQuery] int MoneyAccountId, [FromQuery] int year,[FromQuery] int month,[FromQuery]int day)
        {
            try
            {
                List<MoneyAccountOperation> list = new List<MoneyAccountOperation>();
                {
                    var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
                    list.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(PayINList));
                }
                {
                    var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
                    list.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(PayOUTList));
                }
                {
                    var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
                    list.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(ExchangeOPRList));
                }
                {
                    var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)
                                    && x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
                    list.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, MoneyTransformOPRList));

                }

                return Ok(list);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:DayOperation,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("month_report")]
        public ActionResult<IEnumerable<MoneyAccountReport_InDay>> MonthReport([FromQuery] int MoneyAccountId, [FromQuery] int year, [FromQuery] int month)
        {
            try
            {
                List<MoneyAccountReport_InDay> list = new List<MoneyAccountReport_InDay>();
                var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Month == month && x.Date.Year == year).ToList();
                var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Month == month && x.Date.Year == year).ToList();
                var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Month == month && x.Date.Year == year).ToList();
                var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)&&
                x.Date.Month == month && x.Date.Year == year).ToList();

                int max_days = DateTime.DaysInMonth(year, month);
                for(int i = 1; i <= max_days; i++)
                {
                    int paysin_count, paysout_count, exchangeoprs_count, moneytransformoprsIN_count, moneytransformoprsOUT_count;
                    List<MoneyAccountOperation> operations = new List<MoneyAccountOperation>();
                    
                    {
                        var day_payinlist = PayINList.Where(x => x.Date.Day == i).ToList();
                        paysin_count = day_payinlist.Count;
                        operations.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(day_payinlist));
                    }
                    {
                        var day_payoutlist = PayOUTList.Where(x => x.Date.Day == i).ToList();
                        paysout_count = day_payoutlist.Count;
                        operations.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(day_payoutlist));
                    }
                    {
                        var day_exchangeoprlist = ExchangeOPRList.Where(x => x.Date.Day == i).ToList();
                        exchangeoprs_count = day_exchangeoprlist.Count;
                        operations.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(day_exchangeoprlist));
                    }
                    {
                        var day_moneytransformoprlist = MoneyTransformOPRList.Where(x => x.Date.Day == i).ToList();
                        moneytransformoprsIN_count = day_moneytransformoprlist.Where(x => x.TargetMoneyAccountId == MoneyAccountId).Count();
                        moneytransformoprsOUT_count = day_moneytransformoprlist.Where(x => x.SourceMoneyAccountId == MoneyAccountId).Count();
                        operations.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, day_moneytransformoprlist));
                    }
                    var report_in_day = new MoneyAccountReport_InDay()
                    {
                        DateDayNo = i,
                        Date_day = new DateTime(year, month, i),
                        PaysIN_Count = paysin_count,
                        PaysOUT_Count = paysout_count,
                        ExchangeOPR_Count = exchangeoprs_count,
                        MoneyTransform_IN_Count = moneytransformoprsIN_count,
                        MoneyTransform_OUT_Count = moneytransformoprsOUT_count,
                        MoneyIN_Value = MoneyAccountOperation.Get_MoneyIN_Value(operations),
                        MoneyIN_Real_Value = operations.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.RealValue),
                        MoneyOUT_Value = MoneyAccountOperation.Get_MoneyOUT_Value(operations),
                        MoneyOUT_Real_Value = operations.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.RealValue)
                    };
                    list.Add(report_in_day);

                }
                return Ok(list);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:MonthReport,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("year_report")]
        public ActionResult<IEnumerable<MoneyAccountReport_InMonth>> YearReport([FromQuery] int MoneyAccountId,[FromQuery] int year)
        {
            try
            {

                List<MoneyAccountReport_InMonth> list = new List<MoneyAccountReport_InMonth>();
                var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Year == year).ToList();
                var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Year == year).ToList();
                var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Year == year).ToList();
                var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId) &&
                 x.Date.Year == year).ToList();

                for (int i = 1; i <= 12; i++)
                {
                    int paysin_count, paysout_count, exchangeoprs_count, moneytransformoprsIN_count, moneytransformoprsOUT_count;
                    List<MoneyAccountOperation> operations = new List<MoneyAccountOperation>();

                    {
                        var day_payinlist = PayINList.Where(x => x.Date.Month == i).ToList();
                        paysin_count = day_payinlist.Count;
                        operations.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(day_payinlist));
                    }
                    {
                        var day_payoutlist = PayOUTList.Where(x => x.Date.Month == i).ToList();
                        paysout_count = day_payoutlist.Count;
                        operations.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(day_payoutlist));
                    }
                    {
                        var day_exchangeoprlist = ExchangeOPRList.Where(x => x.Date.Month == i).ToList();
                        exchangeoprs_count = day_exchangeoprlist.Count;
                        operations.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(day_exchangeoprlist));
                    }
                    {
                        var day_moneytransformoprlist = MoneyTransformOPRList.Where(x => x.Date.Month == i).ToList();
                        moneytransformoprsIN_count = day_moneytransformoprlist.Where(x => x.TargetMoneyAccountId == MoneyAccountId).Count();
                        moneytransformoprsOUT_count = day_moneytransformoprlist.Where(x => x.SourceMoneyAccountId == MoneyAccountId).Count();
                        operations.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, day_moneytransformoprlist));
                    }
                    var report_in_month = new MoneyAccountReport_InMonth()
                    {
                        Year_Month = i,
                        Year_Month_Name = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i),
                        PaysIN_Count = paysin_count,
                        PaysOUT_Count = paysout_count,
                        ExchangeOPR_Count = exchangeoprs_count,
                        MoneyTransform_IN_Count = moneytransformoprsIN_count,
                        MoneyTransform_OUT_Count = moneytransformoprsOUT_count,
                        MoneyIN_Value = MoneyAccountOperation.Get_MoneyIN_Value(operations),
                        MoneyIN_Real_Value = operations.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.RealValue),
                        MoneyOUT_Value = MoneyAccountOperation.Get_MoneyOUT_Value(operations),
                        MoneyOUT_Real_Value = operations.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.RealValue)
                    };
                    list.Add(report_in_month);

                }
                return Ok(list);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:YearReport,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("year_range_report")]
        public ActionResult<IEnumerable<MoneyAccountReport_InYear>> YearRangeReport([FromQuery] int MoneyAccountId, [FromQuery] int year1, [FromQuery] int year2)
        {
            try
            {

                List<MoneyAccountReport_InYear> list = new List<MoneyAccountReport_InYear>();
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
                var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId
                && x.Date.Year >= minYear&&x.Date.Year<=maxYear).ToList();
                var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId
                && x.Date.Year >= minYear && x.Date.Year <= maxYear).ToList();
                var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId
                && x.Date.Year >= minYear && x.Date.Year <= maxYear).ToList();
                var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)
                 && x.Date.Year >= minYear && x.Date.Year <= maxYear).ToList();

                for (int i = minYear; i <= maxYear; i++)
                {
                    int paysin_count, paysout_count, exchangeoprs_count, moneytransformoprsIN_count, moneytransformoprsOUT_count;
                    List<MoneyAccountOperation> operations = new List<MoneyAccountOperation>();

                    {
                        var day_payinlist = PayINList.Where(x => x.Date.Month == i).ToList();
                        paysin_count = day_payinlist.Count;
                        operations.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(day_payinlist));
                    }
                    {
                        var day_payoutlist = PayOUTList.Where(x => x.Date.Month == i).ToList();
                        paysout_count = day_payoutlist.Count;
                        operations.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(day_payoutlist));
                    }
                    {
                        var day_exchangeoprlist = ExchangeOPRList.Where(x => x.Date.Month == i).ToList();
                        exchangeoprs_count = day_exchangeoprlist.Count;
                        operations.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(day_exchangeoprlist));
                    }
                    {
                        var day_moneytransformoprlist = MoneyTransformOPRList.Where(x => x.Date.Month == i).ToList();
                        moneytransformoprsIN_count = day_moneytransformoprlist.Where(x => x.TargetMoneyAccountId == MoneyAccountId).Count();
                        moneytransformoprsOUT_count = day_moneytransformoprlist.Where(x => x.SourceMoneyAccountId == MoneyAccountId).Count();
                        operations.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, day_moneytransformoprlist));
                    }
                    var report_in_year = new MoneyAccountReport_InYear()
                    {
                        Year = i,
                        PaysIN_Count = paysin_count,
                        PaysOUT_Count = paysout_count,
                        ExchangeOPR_Count = exchangeoprs_count,
                        MoneyTransform_IN_Count = moneytransformoprsIN_count,
                        MoneyTransform_OUT_Count = moneytransformoprsOUT_count,
                        MoneyIN_Value = MoneyAccountOperation.Get_MoneyIN_Value(operations),
                        MoneyIN_Real_Value = operations.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.RealValue),
                        MoneyOUT_Value = MoneyAccountOperation.Get_MoneyOUT_Value(operations),
                        MoneyOUT_Real_Value = operations.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.RealValue)
                    };
                    list.Add(report_in_year);

                }
                return Ok(list);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:YearRangeReport,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("currency_report_in_day")]
        public ActionResult<IEnumerable<MoneyAccount_CurrencyReport>> CurrencyReportInDay([FromQuery] int MoneyAccountId, [FromQuery] int year, [FromQuery] int month, [FromQuery] int day)
        {
            try
            {
                
                List<MoneyAccount_CurrencyReport> list = new List<MoneyAccount_CurrencyReport>();
                List<MoneyAccountOperation> operations = new List<MoneyAccountOperation>();
                {
                    var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(PayINList));
                }
                {
                    var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(PayOUTList));
                }
                {
                    var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(ExchangeOPRList));
                }
                {
                    var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)
                                    && x.Date.Day == day && x.Date.Month == month && x.Date.Year == year).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, MoneyTransformOPRList));

                }
                List<int> CurrencyIdList = operations.Select(x => x.CurrencyID).Distinct().ToList();
                for(int i = 0; i < CurrencyIdList.Count; i++)
                {
                    var operations_currency_List = operations.Where(x => x.CurrencyID == CurrencyIdList[i]).ToList();
                    var moneyAccount_CurrencyReport = new MoneyAccount_CurrencyReport()
                    {
                        CurrencyID = operations_currency_List[0].CurrencyID,
                        CurrencyName = operations_currency_List[0].CurrencyName,
                        CurrencySymbol = operations_currency_List[0].CurrencySymbol,
                        MoneyIN_FromSells = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_SELL).Sum(x => x.Value),
                        MoneyIN_FromMaintenance = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_MAINTENANCE).Sum(x => x.Value),
                        MoneyIN_FromExchangeOPR = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value),
                        MoneyIN_FromMoneyTransform = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value),
                        MoneyIN_FromOther = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType == null).Sum(x => x.Value),

                        MoneyOUT_ByBuy = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_BUY).Sum(x => x.Value),
                        MoneyOUT_ByEmpPayOrders = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType != null && x.TradeOperationType == Operation.Employee_PayOrder).Sum(x => x.Value),
                        MoneyOUT_ByExchangeOPR = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value),
                        MoneyOUT_ByMoneyTransform = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value),
                        MoneyOUT_ByOther = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType == null).Sum(x => x.Value),


                    };
                    list.Add(moneyAccount_CurrencyReport);
                }
                return Ok(list);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:CurrencyReportInDay,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("currency_report_in_month")]
        public ActionResult<IEnumerable<MoneyAccount_CurrencyReport>> CurrencyReportInMonth([FromQuery] int MoneyAccountId, [FromQuery] int year, [FromQuery] int month)
        {
            try
            {

                List<MoneyAccount_CurrencyReport> list = new List<MoneyAccount_CurrencyReport>();
                List<MoneyAccountOperation> operations = new List<MoneyAccountOperation>();
                {
                    var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Month == month && x.Date.Year == year).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(PayINList));
                }
                {
                    var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Month == month && x.Date.Year == year).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(PayOUTList));
                }
                {
                    var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Month == month && x.Date.Year == year).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(ExchangeOPRList));
                }
                {
                    var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)
                                     && x.Date.Month == month && x.Date.Year == year).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, MoneyTransformOPRList));

                }
                List<int> CurrencyIdList = operations.Select(x => x.CurrencyID).Distinct().ToList();
                for (int i = 0; i < CurrencyIdList.Count; i++)
                {
                    var operations_currency_List = operations.Where(x => x.CurrencyID == CurrencyIdList[i]).ToList();
                    var moneyAccount_CurrencyReport = new MoneyAccount_CurrencyReport()
                    {
                        CurrencyID = operations_currency_List[0].CurrencyID,
                        CurrencyName = operations_currency_List[0].CurrencyName,
                        CurrencySymbol = operations_currency_List[0].CurrencySymbol,
                        MoneyIN_FromSells = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_SELL).Sum(x => x.Value),
                        MoneyIN_FromMaintenance = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_MAINTENANCE).Sum(x => x.Value),
                        MoneyIN_FromExchangeOPR = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value),
                        MoneyIN_FromMoneyTransform = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value),
                        MoneyIN_FromOther = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType == null).Sum(x => x.Value),

                        MoneyOUT_ByBuy = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_BUY).Sum(x => x.Value),
                        MoneyOUT_ByEmpPayOrders = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType != null && x.TradeOperationType == Operation.Employee_PayOrder).Sum(x => x.Value),
                        MoneyOUT_ByExchangeOPR = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value),
                        MoneyOUT_ByMoneyTransform = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value),
                        MoneyOUT_ByOther = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType == null).Sum(x => x.Value),


                    };
                    list.Add(moneyAccount_CurrencyReport);
                }
                return Ok(list);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:MonthReport,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("currency_report_in_year")]
        public ActionResult<IEnumerable<MoneyAccount_CurrencyReport>> CurrencyReportInYear([FromQuery] int MoneyAccountId, [FromQuery] int year)
        {
            try
            {
                List<MoneyAccount_CurrencyReport> list = new List<MoneyAccount_CurrencyReport>();
                List<MoneyAccountOperation> operations = new List<MoneyAccountOperation>();
                {
                    var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Year == year).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(PayINList));
                }
                {
                    var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Year == year).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(PayOUTList));
                }
                {
                    var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId  && x.Date.Year == year).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(ExchangeOPRList));
                }
                {
                    var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)
                                      && x.Date.Year == year).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, MoneyTransformOPRList));

                }
                List<int> CurrencyIdList = operations.Select(x => x.CurrencyID).Distinct().ToList();
                for (int i = 0; i < CurrencyIdList.Count; i++)
                {
                    var operations_currency_List = operations.Where(x => x.CurrencyID == CurrencyIdList[i]).ToList();
                    var moneyAccount_CurrencyReport = new MoneyAccount_CurrencyReport()
                    {
                        CurrencyID = operations_currency_List[0].CurrencyID,
                        CurrencyName = operations_currency_List[0].CurrencyName,
                        CurrencySymbol = operations_currency_List[0].CurrencySymbol,
                        MoneyIN_FromSells = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_SELL).Sum(x => x.Value),
                        MoneyIN_FromMaintenance = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_MAINTENANCE).Sum(x => x.Value),
                        MoneyIN_FromExchangeOPR = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value),
                        MoneyIN_FromMoneyTransform = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value),
                        MoneyIN_FromOther = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType == null).Sum(x => x.Value),

                        MoneyOUT_ByBuy = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_BUY).Sum(x => x.Value),
                        MoneyOUT_ByEmpPayOrders = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType != null && x.TradeOperationType == Operation.Employee_PayOrder).Sum(x => x.Value),
                        MoneyOUT_ByExchangeOPR = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value),
                        MoneyOUT_ByMoneyTransform = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value),
                        MoneyOUT_ByOther = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType == null).Sum(x => x.Value),


                    };
                    list.Add(moneyAccount_CurrencyReport);
                }
                return Ok(list);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:YearReport,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("currency_report_in_yearrange")]
        public ActionResult<IEnumerable<MoneyAccount_CurrencyReport>> CurrencyReportInYearRange([FromQuery] int MoneyAccountId, [FromQuery] int year1, [FromQuery] int year2)
        {
            try
            {
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

                List<MoneyAccount_CurrencyReport> list = new List<MoneyAccount_CurrencyReport>();
                List<MoneyAccountOperation> operations = new List<MoneyAccountOperation>();
                {
                    var PayINList = PayIN_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Year >= minYear && x.Date.Year <=maxYear).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_PayIN_To_MoneyAccountOperation(PayINList));
                }
                {
                    var PayOUTList = PayOUT_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId &&  x.Date.Year >= minYear && x.Date.Year <= maxYear).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_PayOUT_To_MoneyAccountOperation(PayOUTList));
                }
                {
                    var ExchangeOPRList = ExchangeOPR_Repo.List().Where(x => x.MoneyAccountId == MoneyAccountId && x.Date.Year >= minYear && x.Date.Year <= maxYear).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_ExchangeOPR_To_MoneyAccountOperation(ExchangeOPRList));
                }
                {
                    var MoneyTransformOPRList = MoneyTransFormOPR_Repo.List().Where(x => (x.SourceMoneyAccountId == MoneyAccountId || x.TargetMoneyAccountId == MoneyAccountId)
                                     && x.Date.Year >= minYear && x.Date.Year <= maxYear).ToList();
                    operations.AddRange(MoneyAccountOperation.Convert_MoneyTransformOPR_To_MoneyAccountOperation(MoneyAccountId, MoneyTransformOPRList));

                }
                List<int> CurrencyIdList = operations.Select(x => x.CurrencyID).Distinct().ToList();
                for (int i = 0; i < CurrencyIdList.Count; i++)
                {
                    var operations_currency_List = operations.Where(x => x.CurrencyID == CurrencyIdList[i]).ToList();
                    var moneyAccount_CurrencyReport = new MoneyAccount_CurrencyReport()
                    {
                        CurrencyID = operations_currency_List[0].CurrencyID,
                        CurrencyName = operations_currency_List[0].CurrencyName,
                        CurrencySymbol = operations_currency_List[0].CurrencySymbol,
                        MoneyIN_FromSells = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_SELL).Sum(x => x.Value),
                        MoneyIN_FromMaintenance = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_MAINTENANCE).Sum(x => x.Value),
                        MoneyIN_FromExchangeOPR = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value),
                        MoneyIN_FromMoneyTransform = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value),
                        MoneyIN_FromOther = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType == null).Sum(x => x.Value),

                        MoneyOUT_ByBuy = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_BUY).Sum(x => x.Value),
                        MoneyOUT_ByEmpPayOrders = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType != null && x.TradeOperationType == Operation.Employee_PayOrder).Sum(x => x.Value),
                        MoneyOUT_ByExchangeOPR = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value),
                        MoneyOUT_ByMoneyTransform = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value),
                        MoneyOUT_ByOther = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType == null).Sum(x => x.Value),


                    };
                    list.Add(moneyAccount_CurrencyReport);
                }
                return Ok(list);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:YearRangeReport,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
