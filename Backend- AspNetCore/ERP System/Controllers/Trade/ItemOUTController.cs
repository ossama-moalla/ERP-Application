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
    public class ItemOUTController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<ItemOUT> ItemOUT_repo;
        public ItemOUTController(ILogger<ItemOUTController> logger, IApplicationRepository<ItemOUT> ItemOUT_repo)
        {
            this.logger = logger;
            this.ItemOUT_repo = ItemOUT_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] ItemOUT ItemOUT)
        {
            try
            {
                ObjectResult d = VerifyData(ItemOUT);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        ItemOUT_repo.Add(ItemOUT);
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
                logger.LogError("Controller:ItemOUT,Method:Add,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] ItemOUT ItemOUT)
        {
            try
            {
                ObjectResult d = VerifyData(ItemOUT);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        ItemOUT_repo.Update(ItemOUT);
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
                logger.LogError("Controller:ItemOUT,Method:Update,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                ItemOUT_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemOUT,Method:Delete,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<ItemOUT>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(ItemOUT_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemOUT,Method:Info,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<ItemOUT>>> List()
        {
            try
            {
                var ItemOUTies = ItemOUT_repo.List().ToList();
                return Ok(ItemOUTies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemOUT,Method:List,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(ItemOUT ItemOUT)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("ItemOUT Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}
