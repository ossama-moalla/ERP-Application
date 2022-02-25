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
    public class SalesBillController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<SalesBill> SalesBill_repo;
        public SalesBillController(ILogger<SalesBillController> logger, IApplicationRepository<SalesBill> SalesBill_repo)
        {
            this.logger = logger;
            this.SalesBill_repo = SalesBill_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] SalesBill SalesBill)
        {
            try
            {
                ObjectResult d = VerifyData(SalesBill);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        SalesBill_repo.Add(SalesBill);
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
                logger.LogError("Controller:SalesBill,Method:Add,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] SalesBill SalesBill)
        {
            try
            {
                ObjectResult d = VerifyData(SalesBill);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        SalesBill_repo.Update(SalesBill);
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
                logger.LogError("Controller:SalesBill,Method:Update,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                SalesBill_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SalesBill,Method:Delete,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<SalesBill>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(SalesBill_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SalesBill,Method:Info,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<SalesBill>>> List()
        {
            try
            {
                var SalesBillies = SalesBill_repo.List().ToList();
                return Ok(SalesBillies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SalesBill,Method:List,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(SalesBill SalesBill)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("SalesBill Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}
