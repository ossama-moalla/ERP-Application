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
    public class SellTypeController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<SellType> SellType_repo;
        public SellTypeController(ILogger<SellTypeController> logger, IApplicationRepository<SellType> SellType_repo)
        {
            this.logger = logger;
            this.SellType_repo = SellType_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] SellType SellType)
        {
            try
            {
                ObjectResult d = VerifyData(SellType);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         SellType_repo.Add(SellType);
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
                logger.LogError("Controller:SellType,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] SellType SellType)
        {
            try
            {
                ObjectResult d = VerifyData(SellType);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        SellType_repo.Update(SellType);
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
                logger.LogError("Controller:SellType,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                SellType_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SellType,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<SellType>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(SellType_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SellType,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<SellType>>> List()
        {
            try
            {
                var SellTypeies = SellType_repo.List().ToList();
                return Ok(SellTypeies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SellType,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(SellType SellType)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("SellType Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}

