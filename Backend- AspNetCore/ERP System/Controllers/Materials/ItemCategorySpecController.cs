using ERP_System.Models.Materials;
using ERP_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                ObjectResult d = VerifyData(CategorySpec);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    if (d.Value == null)
                    {
                        ItemCategorySpec_Repo.Add(CategorySpec);
                        return Ok();
                    }
                    else
                        return Conflict(d.Value);

                }
                else
                    throw new Exception("VerifyData :Error");

            }
            catch (Exception e)
            {
                logger.LogError("Item Category Add:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Errror");
            }
        }
        [HttpPut("update")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult Update(ItemCategorySpec CategorySpec)
        {
            try
            {
                ObjectResult d = VerifyData(CategorySpec);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    if (d.Value == null)
                    {
                         ItemCategorySpec_Repo.Update(CategorySpec);
                        return Ok();
                    }
                    else
                        return Conflict(d.Value);

                }
                else
                    throw new Exception("VerifyData :Error");
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
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(ItemCategorySpec categoryspec)
        {
            try
            {
                string nameError = null, indexError = null;
                if (ItemCategorySpec_Repo.List().Where(x => x.name == categoryspec.name
                    && x.CategoryID == categoryspec.CategoryID).Count() > 0)
                    nameError = $"SpecName '{categoryspec.name}' is already in use.";
                if (ItemCategorySpec_Repo.List().Where(x => x.index == categoryspec.index
                    && x.CategoryID == categoryspec.CategoryID).Count() > 0)
                    indexError = $"Index [{ categoryspec.index}] is already in use.";

                if (nameError == null && indexError == null)
                    return Ok(null);
                else
                    return Ok(new { name = nameError, index = indexError });
            }
            catch (Exception e)
            {
                logger.LogError("Item Category Spec VerifyData:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
       
    }
}
