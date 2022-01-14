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
    public class PayinController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<PayIN> PayIN_repo;
        public PayinController(ILogger<PayinController> logger, IApplicationRepository<PayIN> PayIN_repo)
        {
            this.logger = logger;
            this.PayIN_repo = PayIN_repo;
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                PayIN_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PayIN,Method:Delete,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<PayIN>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(PayIN_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PayIN,Method:Info,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<PayIN>>> List([FromQuery] int CategoryID)
        {
            try
            {
                return Ok(PayIN_repo.List().ToList());
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PayIN,Method:List,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
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
                    if(oldpayin.OperationId!=PayIN.OperationId||oldpayin.OperationType!=PayIN.OperationType)
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
