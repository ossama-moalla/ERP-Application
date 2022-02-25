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
    public class RavageOPRController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<RavageOPR> RavageOPR_repo;
        public RavageOPRController(ILogger<RavageOPRController> logger, IApplicationRepository<RavageOPR> RavageOPR_repo)
        {
            this.logger = logger;
            this.RavageOPR_repo = RavageOPR_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] RavageOPR RavageOPR)
        {
            try
            {
                ObjectResult d = VerifyData(RavageOPR);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        RavageOPR_repo.Add(RavageOPR);
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
                logger.LogError("Controller:RavageOPR,Method:Add,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] RavageOPR RavageOPR)
        {
            try
            {
                ObjectResult d = VerifyData(RavageOPR);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        RavageOPR_repo.Update(RavageOPR);
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
                logger.LogError("Controller:RavageOPR,Method:Update,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                RavageOPR_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:RavageOPR,Method:Delete,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<RavageOPR>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(RavageOPR_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:RavageOPR,Method:Info,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<RavageOPR>>> List()
        {
            try
            {
                var RavageOPRies = RavageOPR_repo.List().ToList();
                return Ok(RavageOPRies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:RavageOPR,Method:List,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(RavageOPR RavageOPR)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("RavageOPR Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}
