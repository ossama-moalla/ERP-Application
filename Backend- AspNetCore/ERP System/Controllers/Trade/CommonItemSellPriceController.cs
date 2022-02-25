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
    public class CommonItemSellPriceController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<CommonItemSellPrice> CommonItemSellPrice_repo;
        public CommonItemSellPriceController(ILogger<CommonItemSellPriceController> logger, IApplicationRepository<CommonItemSellPrice> CommonItemSellPrice_repo)
        {
            this.logger = logger;
            this.CommonItemSellPrice_repo = CommonItemSellPrice_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] CommonItemSellPrice CommonItemSellPrice)
        {
            try
            {
                ObjectResult d = VerifyData(CommonItemSellPrice);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        CommonItemSellPrice_repo.Add(CommonItemSellPrice);
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
                logger.LogError("Controller:CommonItemSellPrice,Method:Add,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] CommonItemSellPrice CommonItemSellPrice)
        {
            try
            {
                ObjectResult d = VerifyData(CommonItemSellPrice);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        CommonItemSellPrice_repo.Update(CommonItemSellPrice);
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
                logger.LogError("Controller:CommonItemSellPrice,Method:Update,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                CommonItemSellPrice_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:CommonItemSellPrice,Method:Delete,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<CommonItemSellPrice>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(CommonItemSellPrice_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:CommonItemSellPrice,Method:Info,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<CommonItemSellPrice>>> List()
        {
            try
            {
                var CommonItemSellPriceies = CommonItemSellPrice_repo.List().ToList();
                return Ok(CommonItemSellPriceies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:CommonItemSellPrice,Method:List,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(CommonItemSellPrice CommonItemSellPrice)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("CommonItemSellPrice Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}
