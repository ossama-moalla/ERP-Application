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
    public class PayoutController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<PayOUT> PayOUT_repo;
        private readonly IApplicationRepository<MoneyAccount> MoneyAccount_Repo;

        public PayoutController(ILogger<PayoutController> logger,
            IApplicationRepository<PayOUT> PayOUT_repo, IApplicationRepository<MoneyAccount> MoneyAccount_Repo)
        {
            this.logger = logger;
            this.PayOUT_repo = PayOUT_repo;
            this.MoneyAccount_Repo = MoneyAccount_Repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] PayOUT PayOUT)
        {
            try
            {
                ObjectResult d = VerifyData(PayOUT);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         PayOUT_repo.Add(PayOUT);
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
                logger.LogError("Controller:PayOUT,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] PayOUT PayOUT)
        {
            try
            {
                ObjectResult d = VerifyData(PayOUT);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                          PayOUT_repo.Update(PayOUT);
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
                logger.LogError("Controller:PayOUT,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                //check money ammount if value exists in money account
                 PayOUT_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PayOUT,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<PayOUT>> Info([FromQuery] int id)
        {
            try
            {
                var payout = PayOUT_repo.GetByID(id);
                if (payout == null) return NotFound();
                return Ok(payout);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PayOUT,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<PayOUT>>> List()
        {
            try
            {
                var payoutlist = PayOUT_repo.List().ToList();
                return Ok(payoutlist);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PayOUT,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(PayOUT PayOUT)
        {
            try
            {
                var oldpayin = PayOUT_repo.GetByID(PayOUT.Id);
                double moneyaccount_currency_value;
                {
                    var moneyaccount = MoneyAccount_Repo.GetByID(PayOUT.MoneyAccountId);
                    moneyaccount_currency_value =
                        moneyaccount.MoneyAccountValue_By_Currency(PayOUT.CurrencyId);
                }

                if (oldpayin != null)
                {
                    if (PayOUT.Value > moneyaccount_currency_value+ oldpayin.Value)
                        return BadRequest(new ErrorResponse()
                        { Message = "No Enough Money to do this operation" });
                    if (oldpayin.OperationId != PayOUT.OperationId || oldpayin.OperationType != PayOUT.OperationType)
                        return BadRequest(new ErrorResponse()
                        { Message = "Operation Info Cant Be Changed" });
                }
                if (PayOUT.ExchangeRate <= 0)
                    return Ok(new ErrorResponse()
                    { Message = "ExchangeRate Must Be Greater Than Zero" });
                else if (PayOUT.Value <= 0)
                    return Ok(new ErrorResponse()
                    { Message = "Money Value Must Be Greater Than Zero" });
                else if (PayOUT.CurrencyId == -1 && PayOUT.ExchangeRate != 1)
                    return Ok(new ErrorResponse()
                    { Message = "Exchange Rate For Reference Currency[Dollar] Must Be 1" });

                else if (PayOUT.Value > moneyaccount_currency_value)
                    return BadRequest(new ErrorResponse()
                    { Message = "No Enough Money to do this operation" });
                else if (PayOUT.OperationId != null || PayOUT.OperationType != null)
                {
                    if ((PayOUT.OperationId == null || PayOUT.OperationType != null) ||
                        (PayOUT.OperationId != null || PayOUT.OperationType == null))
                    {
                        return BadRequest(new ErrorResponse()
                        { Message = "Operation Id And Type Inncorrect" });
                    }
                    else
                    {
                        return Ok(null);//check Operation Info In Operation Class-soon-
                    }
                }
                else return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("PayOUT Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }
    }
}
