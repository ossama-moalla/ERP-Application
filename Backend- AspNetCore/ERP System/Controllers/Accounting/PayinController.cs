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
    public class PayinController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<PayIN> PayIN_repo;
        private readonly IApplicationRepository<MoneyAccount> MoneyAccount_Repo;
        public PayinController(ILogger<PayinController> logger, IApplicationRepository<PayIN> PayIN_repo,
            IApplicationRepository<MoneyAccount> MoneyAccount_Repo)
        {
            this.logger = logger;
            this.PayIN_repo = PayIN_repo;
            this.MoneyAccount_Repo = MoneyAccount_Repo;

        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] PayIN PayIN)
        {
            try
            {
                ObjectResult d = VerifyData(PayIN);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         PayIN_repo.Add(PayIN);
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
                logger.LogError("Controller:PayIN,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] PayIN PayIN)
        {
            try
            {
                ObjectResult d = VerifyData(PayIN);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         PayIN_repo.Update(PayIN);
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
                logger.LogError("Controller:PayIN,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var payin = PayIN_repo.GetByID(id);
                if (payin == null) return NotFound();
                double moneyaccount_currency_value;
                {
                    var moneyaccount = MoneyAccount_Repo.GetByID(payin.MoneyAccountId);
                    moneyaccount_currency_value =
                        moneyaccount.MoneyAccountValue_By_Currency(payin.CurrencyId);
                }
                
                if(moneyaccount_currency_value-payin.Value < 0) 
                    return BadRequest(new ErrorResponse()
                        { Message = "delete failed! money value in account  cant be under  zero" });
                 PayIN_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PayIN,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            } 
        }
        [HttpGet("Info")]
        public async Task<ActionResult<PayIN>> Info([FromQuery] int id)
        {
            try
            {
                var payin = PayIN_repo.GetByID(id);
                if (payin == null) return NotFound();
                return Ok(payin);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PayIN,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<PayIN>>> List()
        {
            try
            {
                return Ok(PayIN_repo.List());
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PayIN,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(PayIN PayIN)
        {
            try
            {
                var oldpayin = PayIN_repo.GetByID(PayIN.Id);
                if (oldpayin != null)
                {
                    double moneyaccount_currency_value;
                    {
                        var moneyaccount = MoneyAccount_Repo.GetByID(PayIN.MoneyAccountId);
                        moneyaccount_currency_value =
                            moneyaccount.MoneyAccountValue_By_Currency(PayIN.CurrencyId);
                    }
                    
                    if (moneyaccount_currency_value - oldpayin.Value + PayIN.Value < 0)
                        return BadRequest(new ErrorResponse()
                        { Message = "update failed! money value in account  cant be under  zero" });
                    if (oldpayin.OperationId!=PayIN.OperationId||oldpayin.OperationType!=PayIN.OperationType)
                        return BadRequest(new ErrorResponse()
                        { Message = "Operation Info Cant Be Changed" });
                }
                if (PayIN.OperationId != null || PayIN.OperationType != null)
                {
                    if((PayIN.OperationId == null || PayIN.OperationType != null)||
                        (PayIN.OperationId != null || PayIN.OperationType == null))
                    {
                        return BadRequest(new ErrorResponse()
                        { Message = "Operation Id And Type Inncorrect" });
                    }
                    else
                    {
                        return Ok(null);//check Operation Info In Operation Class-soon-
                    }
                }
                else if (PayIN.ExchangeRate <= 0)
                    return Ok(new ErrorResponse()
                    { Message = "ExchangeRate Must Be Greater Than Zero" });
                else if (PayIN.Value <= 0)
                    return Ok(new ErrorResponse()
                    { Message = "Money Value Must Be Greater Than Zero" });
                else if (PayIN.CurrencyId == null && PayIN.ExchangeRate != 1)
                    return Ok(new ErrorResponse()
                    { Message = "Exchange Rate For Reference Currency[Dollar] Must Be 1" });
                else return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("PayIN Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }
    }
}
