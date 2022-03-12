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
        private readonly IApplicationRepository_Set_Unset<CommonItemSellPrice> CommonItemSellPrice_repo;
        public CommonItemSellPriceController(ILogger<CommonItemSellPriceController> logger, IApplicationRepository_Set_Unset<CommonItemSellPrice> CommonItemSellPrice_repo)
        {
            this.logger = logger;
            this.CommonItemSellPrice_repo = CommonItemSellPrice_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] CommonItemSellPrice CommonItemSellPrice)
        {
            try
            {
                CommonItemSellPrice_repo.Set(CommonItemSellPrice);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:CommonItemSellPrice,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] CommonItemSellPrice CommonItemSellPrice)
        {
            try
            {
                CommonItemSellPrice_repo.Update(CommonItemSellPrice);
                return Ok();

            }
            catch (Exception e)
            {
                logger.LogError("Controller:CommonItemSellPrice,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int itemid, [FromQuery] int selltypeId, [FromQuery] int? consumeunitId)
        {
            try
            {
                List<int?> Ids = new List<int?> {itemid,selltypeId,consumeunitId };
                CommonItemSellPrice_repo.UnSet(Ids);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:CommonItemSellPrice,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<CommonItemSellPrice>> Info([FromQuery] int itemid, [FromQuery] int selltypeId, [FromQuery] int? consumeunitId)
        {
            try
            {
                List<int?> Ids = new List<int?> { itemid, selltypeId, consumeunitId };
                 return Ok(CommonItemSellPrice_repo.GetEntity(Ids));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:CommonItemSellPrice,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<CommonItemSellPrice>>> List([FromQuery] int itemid)
        {
            try
            {
                List<int?> Ids = new List<int?> { itemid };
                var CommonItemSellPriceies = CommonItemSellPrice_repo.List(Ids).ToList();
                return Ok(CommonItemSellPriceies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:CommonItemSellPrice,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }

    }

}
