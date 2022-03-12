using ERP_System.Models.Accounting;
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
    public class MoneyTransformOprController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<MoneyTransFormOPR> MoneyTransFormOPR_repo;
        private readonly IApplicationRepository<MoneyAccount> MoneyAccount_Repo;
        public MoneyTransformOprController(ILogger<MoneyTransformOprController> logger,
            IApplicationRepository<MoneyTransFormOPR> MoneyTransFormOPR_repo, IApplicationRepository<MoneyAccount> MoneyAccount_Repo)
        {
            this.logger = logger;
            this.MoneyTransFormOPR_repo = MoneyTransFormOPR_repo;
            this.MoneyAccount_Repo = MoneyAccount_Repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] MoneyTransFormOPR MoneyTransFormOPR)
        {
            try
            {
                ObjectResult d = VerifyData(MoneyTransFormOPR);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         MoneyTransFormOPR_repo.Add(MoneyTransFormOPR);
                        return Ok();
                    }
                    else
                        return BadRequest(err);
                }
                else
                    return d;
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyTransFormOPR,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] MoneyTransFormOPR MoneyTransFormOPR)
        {
            try
            {
                ObjectResult d = VerifyData(MoneyTransFormOPR);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         MoneyTransFormOPR_repo.Update(MoneyTransFormOPR);
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
                logger.LogError("Controller:MoneyTransFormOPR,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var moneytransformopr = MoneyTransFormOPR_repo.GetByID(id);
                if (moneytransformopr == null) return NotFound();
                double target_moneyaccount_currency_value;
                {
                    var Target_moneyaccount = MoneyAccount_Repo.GetByID(moneytransformopr.TargetMoneyAccountId);
                    target_moneyaccount_currency_value =
                        Target_moneyaccount.MoneyAccountValue_By_Currency(moneytransformopr.CurrencyId);

                }

                if (target_moneyaccount_currency_value - moneytransformopr.Value < 0)
                    return BadRequest(new ErrorResponse()
                    { Message = "delete failed! money value in account  cant be less than  zero" });

                 MoneyTransFormOPR_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyTransFormOPR,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<MoneyTransFormOPR>> Info([FromQuery] int id)
        {
            try
            {
                var moneytransformopr = MoneyTransFormOPR_repo.GetByID(id);
                if (moneytransformopr == null) return NotFound();
                return Ok(moneytransformopr);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyTransFormOPR,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<MoneyTransFormOPR>>> List()
        {
            try
            {
                var list = MoneyTransFormOPR_repo.List().ToList();
                return Ok(list);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyTransFormOPR,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(MoneyTransFormOPR MoneyTransFormOPR)
        {
            try
            {
                var oldopr = MoneyTransFormOPR_repo.GetByID(MoneyTransFormOPR.Id);
                double source_moneyaccount_currency_value;
                {
                    var Source_moneyaccount = MoneyAccount_Repo.GetByID(MoneyTransFormOPR.SourceMoneyAccountId);
                    source_moneyaccount_currency_value =
                        Source_moneyaccount.MoneyAccountValue_By_Currency(MoneyTransFormOPR.CurrencyId);
                }
                

                if (oldopr != null)
                {
                    if (source_moneyaccount_currency_value + oldopr.Value- MoneyTransFormOPR.Value<0)
                        return BadRequest(new ErrorResponse()
                        { Message = "No Enough Money to do this operation" });
                    double target_moneyaccount_currency_value;
                    {
                        var Target_moneyaccount = MoneyAccount_Repo.GetByID(MoneyTransFormOPR.TargetMoneyAccountId);
                        target_moneyaccount_currency_value =
                            Target_moneyaccount.MoneyAccountValue_By_Currency(MoneyTransFormOPR.CurrencyId);

                    }

                    if (target_moneyaccount_currency_value - oldopr.Value+ MoneyTransFormOPR.Value <0)
                        return BadRequest(new ErrorResponse()
                        { Message = "Money Value in Account by target currency cant be less than zero" });
                }
                
                if (MoneyTransFormOPR.ExchangeRate <= 0 )
                    return Ok(new ErrorResponse()
                    { Message = "ExchangeRate Must Be Greater Than Zero" });
                else if (MoneyTransFormOPR.SourceMoneyAccountId == MoneyTransFormOPR.TargetMoneyAccountId)
                    return Ok(new ErrorResponse()
                    { Message = "Source  And Target MoneyAccounts Must not be Same" });
                else if (MoneyTransFormOPR.Value <= 0)
                    return Ok(new ErrorResponse()
                    { Message = "Out Money Value Must Be Greater Than Zero" });

                else if (MoneyTransFormOPR.CurrencyId == -1 && MoneyTransFormOPR.ExchangeRate != 1)
                    return Ok(new ErrorResponse()
                    { Message = "Exchange Rate For Reference Currency[Dollar] Must Be 1" });
                else if (source_moneyaccount_currency_value - MoneyTransFormOPR.Value<0)
                    return BadRequest(new ErrorResponse()
                    { Message = "No Enough Money to do this operation" });
                else return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("MoneyTransFormOPR Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }
}
