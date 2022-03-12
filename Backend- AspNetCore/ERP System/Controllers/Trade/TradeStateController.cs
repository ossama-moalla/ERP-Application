using ERP_System.Models.Trade;
using ERP_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Controllers.Trade
{
    [Route("Trade/[controller]")]
    [ApiController]
    public class TradeStateController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<TradeState> TradeState_repo;
        public TradeStateController(ILogger<TradeStateController> logger, IApplicationRepository<TradeState> TradeState_repo)
        {
            this.logger = logger;
            this.TradeState_repo = TradeState_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] TradeState TradeState)
        {
            try
            {
                ObjectResult d = VerifyData(TradeState);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         TradeState_repo.Add(TradeState);
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
                logger.LogError("Controller:TradeState,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] TradeState TradeState)
        {
            try
            {
                ObjectResult d = VerifyData(TradeState);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         TradeState_repo.Update(TradeState);
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
                logger.LogError("Controller:TradeState,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                 TradeState_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:TradeState,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<TradeState>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(TradeState_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:TradeState,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<TradeState>>> List()
        {
            try
            {
                var TradeStateies = TradeState_repo.List().ToList();
                return Ok(TradeStateies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:TradeState,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(TradeState TradeState)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("TradeState Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}
