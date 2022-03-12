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
    public class ItemINSellPriceController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository_Set_Unset<ItemINSellPrice> ItemINSellPrice_repo;
        public ItemINSellPriceController(ILogger<ItemINSellPriceController> logger, IApplicationRepository_Set_Unset<ItemINSellPrice> ItemINSellPrice_repo)
        {
            this.logger = logger;
            this.ItemINSellPrice_repo = ItemINSellPrice_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] ItemINSellPrice ItemINSellPrice)
        {
            try
            {
                ObjectResult d = VerifyData(ItemINSellPrice);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         ItemINSellPrice_repo.Set(ItemINSellPrice);
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
                logger.LogError("Controller:ItemINSellPrice,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] ItemINSellPrice ItemINSellPrice)
        {
            try
            {
                ObjectResult d = VerifyData(ItemINSellPrice);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        ItemINSellPrice_repo.Update(ItemINSellPrice);
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
                logger.LogError("Controller:ItemINSellPrice,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int itemInId, [FromQuery] int sellTypeId,[FromQuery] int? consumeUnitId)
        {
            try
            {
                List<int?> Ids = new() { itemInId, sellTypeId, consumeUnitId };
                ItemINSellPrice_repo.UnSet(Ids);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemINSellPrice,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<ItemINSellPrice>> Info([FromQuery] int itemInId, [FromQuery] int sellTypeId, [FromQuery] int? consumeUnitId)
        {
            try
            {
                List<int?> Ids = new () { itemInId, sellTypeId, consumeUnitId };
                var iteminsellprice = ItemINSellPrice_repo.GetEntity(Ids);
                if (iteminsellprice == null) return NotFound();
                return Ok(iteminsellprice);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemINSellPrice,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<ItemINSellPrice>>> List([FromQuery] int itemInId)
        {
            try
            {
                List<int?> Ids = new () { itemInId };

                var ItemINSellPriceies = ItemINSellPrice_repo.List(Ids).ToList();
                return Ok(ItemINSellPriceies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemINSellPrice,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(ItemINSellPrice ItemINSellPrice)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("ItemINSellPrice Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}
