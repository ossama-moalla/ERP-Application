using ERP_System.Models.Materials;
using ERP_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ERP_System.Controllers.Materials
{
    [Route("materials/[controller]")]
    public class ItemCategorySpecRestrictedController : ControllerBase
    {
        ILogger logger;
        IApplicationRepository<ItemCategorySpec_Restrict> ItemCategorySpecRestriced_Repo;
        public ItemCategorySpecRestrictedController(ILogger<ItemCategorySpec_Restrict> logger, IApplicationRepository<ItemCategorySpec_Restrict> ItemCategorySpecRestriced_Repo)
        {
            this.logger = logger;
            this.ItemCategorySpecRestriced_Repo = ItemCategorySpecRestriced_Repo;
        }

        [HttpPost("add")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult Add([FromBody] ItemCategorySpec_Restrict CategorySpec)
        {
            try
            {
                ItemCategorySpecRestriced_Repo.Add(CategorySpec);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut("update")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult Update(ItemCategorySpec_Restrict CategorySpec)
        {
            try
            {
                ItemCategorySpecRestriced_Repo.Update(CategorySpec);
                return Ok();
            }
            catch (Exception e) 
            {
                logger.LogError("ItemCategory Spec Update Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Errror");
            }
        }
        [HttpDelete("delete")]
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                ItemCategorySpecRestriced_Repo.Delete(id);
                return Ok();
            }
            catch(Exception e)
            {
                logger.LogError( "ItemCategorySpecRestriced Delete Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("list")]
        public ActionResult<IEnumerable<ItemCategorySpec_Restrict>> list([FromQuery] int CategoryID)
        {
            try
            {
                return Ok(ItemCategorySpecRestriced_Repo.List().Where(x => x.Category.ID == CategoryID).ToList());
            }
            catch(Exception e)
            {
                logger.LogError("ItemCategorySpecRestriced List Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("info")]
        public ActionResult<ItemCategorySpec_Restrict> info([FromQuery] int id)
        {
            try
            {
                return Ok(ItemCategorySpecRestriced_Repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("ItemCategorySpecRestriced Info Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
