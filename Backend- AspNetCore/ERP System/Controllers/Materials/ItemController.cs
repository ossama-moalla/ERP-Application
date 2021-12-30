using ERP_System.Models.Materials;
using ERP_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Controllers.Materials
{
    [Route("materials/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IApplicationRepositoryEntityAddReturn<Item> Item_repo;
        public ItemController(ILogger<ItemController> logger,IApplicationRepositoryEntityAddReturn<Item> Item_repo)
        {
            this.logger = logger;
            this.Item_repo = Item_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult<Item>> Add([FromBody]Item item)
        {
            try
            {
                ObjectResult d = VerifyData(item);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                        return Ok(Item_repo.Add(item));
                    else
                        return Conflict(err);

                }
                else
                    return d;
            }
            catch(Exception e)
            {
                logger.LogError("Controller:Item,Method:Add,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Item item)
        {
            try
            {
                ObjectResult d = VerifyData(item);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        Item_repo.Update(item);
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
                logger.LogError("Controller:Item,Method:Update,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                Item_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:Item,Method:Delete,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<Item>> Info([FromQuery] int id)
        {
            try
            {
                 return Ok(Item_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:Item,Method:Info,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost("List")]
        public async Task<ActionResult<IEnumerable<Item>>> List([FromQuery] int CategoryID)
        {
            try
            {
                var items = Item_repo.List().Where(x => x.ItemCategoryId == CategoryID).ToList();
                return Ok(items);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:Item,Method:List,Error:"+e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(Item item)
        {
            try
            {
                if (Item_repo.List().Where(x => 
                       x.Name == item.Name
                    && x.Company == item.Company
                    && x.ItemCategoryId == item.ItemCategoryId).Count() > 0)
                    return Ok(new ErrorResponse()
                    { Message = $"Item name:{item.Name} and Company:{item.Company} already in use !" });
                    
                 return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("Item Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }
    }
}
