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
                ObjectResult d = VerifyData(CategorySpec);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    if (d.Value == null)
                    {
                        ItemCategorySpecRestriced_Repo.Add(CategorySpec);
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
                logger.LogError("ItemCategory Restrict Spec  Update Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Errror");
            }
        }
        [HttpPut("update")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult Update(ItemCategorySpec_Restrict CategorySpec)
        {
            try
            {
                ObjectResult d = VerifyData(CategorySpec);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    if (d.Value == null)
                    {
                        ItemCategorySpecRestriced_Repo.Update(CategorySpec);
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
                logger.LogError("ItemCategory Restrict Spec Update Error:" + e.Message);
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
        public ActionResult<IEnumerable<ItemCategorySpec_Restrict>> list([FromQuery] int categoryID)
        {
            try
            {
                return Ok(ItemCategorySpecRestriced_Repo.List().Where(x => x.CategoryID == categoryID).ToList());
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
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(ItemCategorySpec_Restrict categoryspec)
        {
            try
            {
                string nameError = null, indexError = null;
                if (ItemCategorySpecRestriced_Repo.List().Where(x => x.name == categoryspec.name
                    && x.CategoryID == categoryspec.CategoryID).Count() > 0)
                    nameError = $"SpecName '{categoryspec.name}' is already in use.";
                if (ItemCategorySpecRestriced_Repo.List().Where(x => x.index == categoryspec.index
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
