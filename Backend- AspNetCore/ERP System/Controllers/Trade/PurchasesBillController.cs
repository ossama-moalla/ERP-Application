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
    public class PurchasesBillController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<PurchasesBill> PurchasesBill_repo;
        public PurchasesBillController(ILogger<PurchasesBillController> logger, IApplicationRepository<PurchasesBill> PurchasesBill_repo)
        {
            this.logger = logger;
            this.PurchasesBill_repo = PurchasesBill_repo;
        }
        [HttpPut("Add")]
        public async Task<ActionResult> Add([FromBody] PurchasesBill PurchasesBill)
        {
            try
            {
                ObjectResult d = VerifyData(PurchasesBill);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        PurchasesBill_repo.Add(PurchasesBill);
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
                logger.LogError("Controller:PurchasesBill,Method:Add,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] PurchasesBill PurchasesBill)
        {
            try
            {
                ObjectResult d = VerifyData(PurchasesBill);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        PurchasesBill_repo.Update(PurchasesBill);
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
                logger.LogError("Controller:PurchasesBill,Method:Update,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                PurchasesBill_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PurchasesBill,Method:Delete,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<PurchasesBill>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(PurchasesBill_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PurchasesBill,Method:Info,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<PurchasesBill>>> List()
        {
            try
            {
                var PurchasesBillies = PurchasesBill_repo.List().ToList();
                return Ok(PurchasesBillies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PurchasesBill,Method:List,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(PurchasesBill PurchasesBill)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("PurchasesBill Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}
