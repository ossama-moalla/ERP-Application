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
    public class ItemCategorySpecController : ControllerBase
    {
        ILogger logger;
        IApplicationRepository<ItemCategorySpec> ItemCategorySpec_Repo;
        public ItemCategorySpecController(ILogger<ItemCategorySpecController> logger, IApplicationRepository<ItemCategorySpec> ItemCategorySpec_Repo)
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
                var speclist = ItemCategorySpec_Repo.List();
                if (speclist.Where(x => x.index == CategorySpec.index && x.CategoryID == CategorySpec.CategoryID).Count() > 0 
                    || speclist.Where(x => x.name == CategorySpec.name && x.CategoryID == CategorySpec.CategoryID).Count() > 0)
                {
                     throw new MyException("name and index must be unique in Category  ");
                }
                ItemCategorySpec_Repo.Add(CategorySpec);
                return Ok();
            }
            catch(MyException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            }
            catch (Exception e)
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
                var speclist = ItemCategorySpec_Repo.List();
                if (speclist.Where(x => x.index == CategorySpec.index && x.CategoryID == CategorySpec.CategoryID).Count() > 0
                    || speclist.Where(x => x.name == CategorySpec.name && x.CategoryID == CategorySpec.CategoryID).Count() > 0)
                {
                    throw new MyException("name and index must be unique in Category  ");
                }
                ItemCategorySpec_Repo.Update(CategorySpec);
                return Ok();
            }
            catch (MyException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
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
        public ActionResult<IEnumerable<ItemCategorySpec>> list([FromQuery] int categoryID)
        {
            try
            {
                return Ok(ItemCategorySpec_Repo.List().Where(x => x.CategoryID == categoryID).ToList());
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
