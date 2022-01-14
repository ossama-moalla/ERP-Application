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
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeOprController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<ExchangeOPR> ExchangeOpr_repo;
        public ExchangeOprController(ILogger<ExchangeOprController> logger, IApplicationRepository<ExchangeOPR> ExchangeOpr_repo)
        {
            this.logger = logger;
            this.ExchangeOpr_repo = ExchangeOpr_repo;
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                ExchangeOpr_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ExchangeOPR,Method:Delete,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<ExchangeOPR>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(ExchangeOpr_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ExchangeOPR,Method:Info,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<ExchangeOPR>>> List([FromQuery] int CategoryID)
        {
            try
            {
                return Ok(ExchangeOpr_repo.List().ToList());
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ExchangeOPR,Method:List,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(ExchangeOPR ExchangeOPR)
        {
            try
            {
                if (ExchangeOPR.SourceExchangeRate <= 0 || ExchangeOPR.TargetExchangeRate <= 0)
                    return Ok(new ErrorResponse()
                    { Message = "ExchangeRate Must Be Greater Than Zero" });
                else if (ExchangeOPR.SourceCurrencyId == ExchangeOPR.TargetCurrencyId)
                    return Ok(new ErrorResponse()
                    { Message = "Source Currency And Target Currency Must not be Same" });
                else if (ExchangeOPR.OutMoneyValue <= 0)
                    return Ok(new ErrorResponse()
                    { Message = "Out Money Value Must Be Greater Than Zero" });
                else if((ExchangeOPR.SourceCurrencyId==null&&ExchangeOPR.SourceExchangeRate!=1)
                    ||(ExchangeOPR.TargetCurrencyId == null && ExchangeOPR.TargetExchangeRate != 1))
                    return Ok(new ErrorResponse()
                    { Message = "Exchange Rate For Reference Currency[Dollar] Must Be 1" });
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
