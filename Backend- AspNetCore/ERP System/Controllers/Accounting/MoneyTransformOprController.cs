using ERP_System.Models.Accounting;
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
    public class MoneyTransformOprController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<MoneyTransFormOPR> MoneyTransFormOPR_repo;
        public MoneyTransformOprController(ILogger<MoneyTransformOprController> logger, IApplicationRepository<MoneyTransFormOPR> MoneyTransFormOPR_repo)
        {
            this.logger = logger;
            this.MoneyTransFormOPR_repo = MoneyTransFormOPR_repo;
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                MoneyTransFormOPR_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyTransFormOPR,Method:Delete,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<MoneyTransFormOPR>> Info([FromQuery] int id)
        {
            try
            {
                var moneytransformopr = MoneyTransFormOPR_repo.GetByID(id);
                return Ok(MoneyTransFormOPR.ConvertToMoneyTransFormOPR_VM(moneytransformopr));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyTransFormOPR,Method:Info,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<MoneyTransFormOPR>>> List()
        {
            try
            {
                var list = MoneyTransFormOPR_repo.List().ToList();
                return Ok(MoneyTransFormOPR.ConvertToMoneyTransFormOPR_VM(list));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyTransFormOPR,Method:List,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(MoneyTransFormOPR MoneyTransFormOPR)
        {
            try
            {
                if (MoneyTransFormOPR.ExchangeRate <= 0 )
                    return Ok(new ErrorResponse()
                    { Message = "ExchangeRate Must Be Greater Than Zero" });
                else if (MoneyTransFormOPR.SourceMoneyAccountId == MoneyTransFormOPR.TargetMoneyAccountId)
                    return Ok(new ErrorResponse()
                    { Message = "Source  And Target MoneyAccounts Must not be Same" });
                else if (MoneyTransFormOPR.Value <= 0)
                    return Ok(new ErrorResponse()
                    { Message = "Out Money Value Must Be Greater Than Zero" });
                else if (MoneyTransFormOPR.CurrencyId == null && MoneyTransFormOPR.ExchangeRate != 1)
                    return Ok(new ErrorResponse()
                    { Message = "Exchange Rate For Reference Currency[Dollar] Must Be 1" });
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
