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
    [ApiController]
    public class ItemCategorySpecsController : ControllerBase
    {
        ILogger logger;
        IApplicationRepository<ItemCategorySpec> ItemCategorySpec_Repo;
        public ItemCategorySpecsController(ILogger<ItemCategorySpecsController> logger, IApplicationRepository<ItemCategorySpec> ItemCategorySpec_Repo)
        {
            this.logger = logger;
            this.ItemCategorySpec_Repo = ItemCategorySpec_Repo;
        }

        [HttpPost("add")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult Add([FromBody] ItemCategorySpec CategorySpec)
        {
            try
            {
                ItemCategorySpec_Repo.Add(CategorySpec);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut("update")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult Update(ItemCategorySpec CategorySpec)
        {
            try
            {
                ItemCategorySpec_Repo.Update(CategorySpec);
                return Ok();
            }
            catch (Exception e) 
            {
                logger.LogError("ItemCategory Spec Update Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Errror");
            }
        }
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                ItemCategorySpec_Repo.Delete(id);
                return Ok();
            }
            catch(Exception e)
            {
                logger.LogError( "ItemCategorySpec Delete Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("list")]
        public ActionResult<IEnumerable<ItemCategorySpec>> list([FromQuery] int CategoryID)
        {
            try
            {
                return Ok(ItemCategorySpec_Repo.List().Where(x => x.Category.ID == CategoryID).ToList());
            }
            catch(Exception e)
            {
                logger.LogError("ItemCategorySpec List Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("info")]
        public ActionResult<ItemCategorySpec> info([FromQuery] int ID)
        {
            try
            {
                return Ok(ItemCategorySpec_Repo.GetByID(ID));
            }
            catch (Exception e)
            {
                logger.LogError("ItemCategorySpec Info Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
