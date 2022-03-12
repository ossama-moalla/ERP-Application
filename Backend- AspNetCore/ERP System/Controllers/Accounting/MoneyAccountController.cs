using ERP_System.Models.Accounting;
using ERP_System.Models.Accounting.Reports;
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
    public class MoneyAccountController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<MoneyAccount> MoneyAccount_repo;
        IReportByDateTypeRepository<MoneyAccountOperation, MoneyAccount_DayReport, MoneyAccount_MonthReport,
            MoneyAccount_YearReport
            , MoneyAccount_YearRangeReport> MoneyAccountReport_repo;
        public MoneyAccountController(ILogger<MoneyAccountController> logger, 
            IApplicationRepository<MoneyAccount> MoneyAccount_repo,
            IReportByDateTypeRepository<MoneyAccountOperation, MoneyAccount_DayReport, MoneyAccount_MonthReport,
                MoneyAccount_YearReport
            , MoneyAccount_YearRangeReport> MoneyAccountReport_repo)
        {
            this.logger = logger;
            this.MoneyAccount_repo = MoneyAccount_repo;
            this.MoneyAccountReport_repo = MoneyAccountReport_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] MoneyAccount MoneyAccount)
        {
            try
            {
                ObjectResult d = VerifyData(MoneyAccount);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         MoneyAccount_repo.Add(MoneyAccount);
                        return Ok();
                    }
                    else
                        return Conflict(err);
                }
                else
                    return d;
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccount,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] MoneyAccount MoneyAccount)
        {
            try
            {
                ObjectResult d = VerifyData(MoneyAccount);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         MoneyAccount_repo.Update(MoneyAccount);
                        return Ok();
                    }
                    else
                        return Conflict(err);

                }
                else
                    return d;
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccount,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                 MoneyAccount_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccount,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<MoneyAccount>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(MoneyAccount_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccount,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<MoneyAccount>>> List()
        {
            try
            {
                return Ok(MoneyAccount_repo.List().ToList());
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccount,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(MoneyAccount MoneyAccount)
        {
            try
            {
                if (MoneyAccount.Name.Length < 6)
                    return Ok(new ErrorResponse()
                    { Message = "Name must be at least 6 charecters" });

                var oldmoneyaccount = MoneyAccount_repo.GetByID(MoneyAccount.Id);
                if (oldmoneyaccount != null)
                {
                    if (oldmoneyaccount.Name != MoneyAccount.Name)
                    {
                        if (MoneyAccount_repo.List().Where(x => x.Name == MoneyAccount.Name).Count() > 0)
                            return Ok(new ErrorResponse()
                            { Message = $"Money Account Name :{MoneyAccount.Name} is already in use!" });
                    }
                }
                else 
                {
                    if (MoneyAccount_repo.List().Where(x => x.Name == MoneyAccount.Name).Count() > 0)
                        return Ok(new ErrorResponse()
                        { Message = $"Money Account Name :{MoneyAccount.Name} is already in use!" });   
                }
                return Ok(null);

            }
            catch (Exception e)
            {
                logger.LogError("MoneyAccount Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }
        [HttpGet("moneyaccount_value")]
        public ActionResult<string> MoneyAccountValue([FromQuery] int MoneyAccountId)
        {
            try
            {
                var moneyaccount = MoneyAccount_repo.GetByID(MoneyAccountId);
                return Ok(moneyaccount.MoneyAccountValue());
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountController,Method:MoneyAccountValue,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("moneyaccount_value_by_currency")]
        public ActionResult<double> MoneyAccountValueByCurrency([FromQuery] int MoneyAccountId, [FromQuery] int CurrencyID)
        {
            try
            {
                var moneyaccount = MoneyAccount_repo.GetByID(MoneyAccountId);
                return Ok(moneyaccount.MoneyAccountValue_By_Currency(CurrencyID));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountController,Method:MoneyAccountValueByCurrency,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("day_report")]
        public ActionResult<MoneyAccount_DayReport> DayReport([FromQuery] int MoneyAccountId, [FromQuery] int year, [FromQuery] int month, [FromQuery] int day)
        {
            try
            {
                var moneyaccount = MoneyAccount_repo.GetByID(MoneyAccountId);
                return Ok(this.MoneyAccountReport_repo.DayReport(moneyaccount.OperationList, year, month, day));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountController,Method:DayReport,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("month_report")]
        public ActionResult<MoneyAccount_MonthReport> MonthReport([FromQuery] int MoneyAccountId, [FromQuery] int year, [FromQuery] int month)
        {
            try
            {
                var moneyaccount = MoneyAccount_repo.GetByID(MoneyAccountId);
                return Ok(this.MoneyAccountReport_repo.MonthReport(moneyaccount.OperationList, year, month));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountController,Method:MonthReport,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("year_report")]
        public ActionResult<MoneyAccount_YearReport> YearReport([FromQuery] int MoneyAccountId, [FromQuery] int year)
        {
            try
            {
                var moneyaccount = MoneyAccount_repo.GetByID(MoneyAccountId);
                return Ok(this.MoneyAccountReport_repo.YearReport(moneyaccount.OperationList, year));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountController,Method:YearReport,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("year_range_report")]
        public ActionResult<MoneyAccount_YearRangeReport> YearRangeReport([FromQuery] int MoneyAccountId, [FromQuery] int year1, [FromQuery] int year2)
        {
            try
            {
                var moneyaccount = MoneyAccount_repo.GetByID(MoneyAccountId);
                return Ok(this.MoneyAccountReport_repo.YearRangeReport(moneyaccount.OperationList, year1,year2));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccountController,Method:YearRangeReport,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
    }
}
