using ERP_System.Models.Accounting;
using ERP_System.Models.Accounting.Reports;
using ERP_System.Models.Trade;
using ERP_System.Repositories;
using ERP_System.Repositories.Accounting_Repository;
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
        private readonly MoneyAccountReport_Repo MoneyAccountReport_Repo;
        public MoneyAccountReportController(ILogger<MoneyAccountReportController> logger,
             IApplicationRepository<PayIN> PayIN_Repo,
             IApplicationRepository<PayOUT> PayOUT_Repo,
             IApplicationRepository<ExchangeOPR> ExchangeOPR_Repo,
             IApplicationRepository<MoneyTransFormOPR> MoneyTransFormOPR_Repo,
             MoneyAccountReport_Repo MoneyAccountReport_Repo
             )
        {
            this.logger = logger;
            this.PayIN_Repo = PayIN_Repo;
            this.PayOUT_Repo = PayOUT_Repo;
            this.ExchangeOPR_Repo = ExchangeOPR_Repo;
            this.MoneyTransFormOPR_Repo = MoneyTransFormOPR_Repo;
            this.MoneyAccountReport_Repo = MoneyAccountReport_Repo;
        }
        [HttpGet("moneyaccount_value")]
        public ActionResult<string> MoneyAccountValue([FromQuery] int MoneyAccountId)
        {
            try
            {
                return Ok(this.MoneyAccountReport_Repo.MoneyAccountValue(MoneyAccountId));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:MoneyAccountValue,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("moneyaccount_value_by_currency")]
        public ActionResult<double> MoneyAccountValueByCurrency([FromQuery] int MoneyAccountId,[FromQuery] int CurrencyID)
        {
            try
            {
                return Ok(this.MoneyAccountReport_Repo.MoneyAccountValueByCurrency(MoneyAccountId,CurrencyID));
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
                return Ok(this.MoneyAccountReport_Repo.DayReport(MoneyAccountId,year,month,day));
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
                return Ok(this.MoneyAccountReport_Repo.MonthReport(MoneyAccountId,year,month));
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
                return Ok(this.MoneyAccountReport_Repo.YearReport(MoneyAccountId,year));
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
                return Ok(this.MoneyAccountReport_Repo.YearRangeReport(MoneyAccountId,year1,year2));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountReportController,Method:YearRangeReport,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
