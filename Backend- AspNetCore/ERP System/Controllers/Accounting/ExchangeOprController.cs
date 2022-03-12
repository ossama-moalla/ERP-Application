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
    public class ExchangeOprController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<ExchangeOPR> ExchangeOpr_repo;
        private readonly IApplicationRepository<MoneyAccount> MoneyAccount_Repo;
        public ExchangeOprController(ILogger<ExchangeOprController> logger, 
            IApplicationRepository<ExchangeOPR> ExchangeOpr_repo, IApplicationRepository<MoneyAccount> MoneyAccount_Repo)
        {
            this.logger = logger;
            this.ExchangeOpr_repo = ExchangeOpr_repo;
            this.MoneyAccount_Repo = MoneyAccount_Repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] ExchangeOPR ExchangeOPR)
        {
            try
            {
                ObjectResult d = VerifyData(ExchangeOPR);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         ExchangeOpr_repo.Add(ExchangeOPR);
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
                logger.LogError("Controller:ExchangeOPR,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] ExchangeOPR ExchangeOPR)
        {
            try
            {
                ObjectResult d = VerifyData(ExchangeOPR);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         ExchangeOpr_repo.Update(ExchangeOPR);
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
                logger.LogError("Controller:ExchangeOPR,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var exchangeopr = ExchangeOpr_repo.GetByID(id);
                if (exchangeopr == null) return NotFound();
                var moneyaccount = MoneyAccount_Repo.GetByID(exchangeopr.MoneyAccountId);
                double taget_moneyaccount_currency_value =
                    moneyaccount.MoneyAccountValue_By_Currency(exchangeopr.TargetCurrencyId);
                if (taget_moneyaccount_currency_value -
                    ( exchangeopr.OutMoneyValue * exchangeopr.TargetExchangeRate/ exchangeopr.SourceExchangeRate)< 0)
                    return BadRequest(new ErrorResponse()
                    { Message = "delete failed! money value in account  cant be less than  zero" });

                 ExchangeOpr_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ExchangeOPR,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<ExchangeOPR>> Info([FromQuery] int id)
        {
            try
            {
                var exchangeopr = ExchangeOpr_repo.GetByID(id);
                if (exchangeopr == null) return NotFound();
                return Ok(exchangeopr);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ExchangeOPR,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<ExchangeOPR>>> List()
        {
            try
            {
                var list = ExchangeOpr_repo.List().ToList();
                return Ok(list);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ExchangeOPR,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(ExchangeOPR ExchangeOPR)
        {
            try
            {
                var oldopr = ExchangeOpr_repo.GetByID(ExchangeOPR.Id);
                double source_moneyaccount_currency_value;
                {
                    var moneyaccount = MoneyAccount_Repo.GetByID(ExchangeOPR.MoneyAccountId);
                    source_moneyaccount_currency_value =
                        moneyaccount.MoneyAccountValue_By_Currency(ExchangeOPR.SourceCurrencyId);
                }
                
                
                if (oldopr != null)
                {
                    if (source_moneyaccount_currency_value + oldopr.OutMoneyValue- ExchangeOPR.OutMoneyValue<0)
                        return BadRequest(new ErrorResponse()
                        { Message = "Money Value in Account by source currency cant be less than zero" });

                    double target_moneyaccount_currency_value;
                    {
                        var moneyaccount = MoneyAccount_Repo.GetByID(ExchangeOPR.MoneyAccountId);
                        target_moneyaccount_currency_value =
                            moneyaccount.MoneyAccountValue_By_Currency(ExchangeOPR.TargetCurrencyId);
                    }
                    
                    var new_invalue = (ExchangeOPR.OutMoneyValue * ExchangeOPR.TargetExchangeRate / ExchangeOPR.SourceExchangeRate);
                    var old_invalue = (oldopr.OutMoneyValue * oldopr.TargetExchangeRate / oldopr.SourceExchangeRate);
                    if (target_moneyaccount_currency_value - old_invalue+new_invalue<0)
                        return BadRequest(new ErrorResponse()
                        { Message = "Money Value in Account by target currency cant be less than zero" });
                }
                if (ExchangeOPR.SourceExchangeRate <= 0 || ExchangeOPR.TargetExchangeRate <= 0)
                    return Ok(new ErrorResponse()
                    { Message = "ExchangeRate Must Be Greater Than Zero" });
                else if (ExchangeOPR.SourceCurrencyId == ExchangeOPR.TargetCurrencyId)
                    return Ok(new ErrorResponse()
                    { Message = "Source Currency And Target Currency Must not be Same" });
                else if (ExchangeOPR.OutMoneyValue <= 0)
                    return Ok(new ErrorResponse()
                    { Message = "Out Money Value Must Be Greater Than Zero" });
                else if((ExchangeOPR.SourceCurrencyId==-1&&ExchangeOPR.SourceExchangeRate!=1)
                    ||(ExchangeOPR.TargetCurrencyId == -1 && ExchangeOPR.TargetExchangeRate != 1))
                    return Ok(new ErrorResponse()
                    { Message = "Exchange Rate For Reference Currency[Dollar] Must Be 1" });
                else if ( source_moneyaccount_currency_value- ExchangeOPR.OutMoneyValue<0)
                    return BadRequest(new ErrorResponse()
                    { Message = "No Enough Money to do this operation" });
                else return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("ExchangeOPR Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }
}
