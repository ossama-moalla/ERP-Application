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
    public class ItemINStoreReportController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<ItemINStoreReport> ItemINStoreReport_repo;
        public ItemINStoreReportController(ILogger<ItemINStoreReportController> logger, IApplicationRepository<ItemINStoreReport> ItemINStoreReport_repo)
        {
            this.logger = logger;
            this.ItemINStoreReport_repo = ItemINStoreReport_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] ItemINStoreReport ItemINStoreReport)
        {
            try
            {
                ObjectResult d = VerifyData(ItemINStoreReport);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         ItemINStoreReport_repo.Add(ItemINStoreReport);
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
                logger.LogError("Controller:ItemINStoreReport,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] ItemINStoreReport ItemINStoreReport)
        {
            try
            {
                ObjectResult d = VerifyData(ItemINStoreReport);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         ItemINStoreReport_repo.Update(ItemINStoreReport);
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
                logger.LogError("Controller:ItemINStoreReport,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                 ItemINStoreReport_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemINStoreReport,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<ItemINStoreReport>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(ItemINStoreReport_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemINStoreReport,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<ItemINStoreReport>>> List()
        {
            try
            {
                var ItemINStoreReporties = ItemINStoreReport_repo.List().ToList();
                return Ok(ItemINStoreReporties);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemINStoreReport,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(ItemINStoreReport ItemINStoreReport)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("ItemINStoreReport Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}
