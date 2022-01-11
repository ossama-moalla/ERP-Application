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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP_System.Controllers.Materials
{
    [Route("materials/[controller]")]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IApplicationRepositoryEntityAddReturn<ItemCategory> ItemCategory_repo;
        private readonly ILogger logger;
        public ItemCategoryController(IApplicationRepositoryEntityAddReturn<ItemCategory> ItemCategory_repo,ILogger<ItemCategoryController> _logger)
        {
            this.ItemCategory_repo = ItemCategory_repo;
            logger = _logger;
        }

        
        [HttpGet("GetCategories")]
        public async Task<ActionResult<IEnumerable<ItemCategory>>> GetCategories([FromQuery] int? parentid)
        { 
            try
            {
                if (parentid != null)
                    if (ItemCategory_repo.GetByID((int)parentid) == null) return NotFound();
                return Ok(ItemCategory_repo.List().Where(x => x.parentID == parentid).ToList());

            }
            catch (Exception e)
            {
                logger.LogError("Item Category GetCategories Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Message = "Internal Server Error" });
            }
        }
        [HttpGet("path")]
        public ActionResult<IEnumerable<ItemCategory>> GetPath([FromQuery] int id)
        {
            try
            {
                if (ItemCategory_repo.GetByID(id) == null) return NotFound("Gategory Not Found");

                List<ItemCategory> list = new List<ItemCategory>();
                ItemCategory parentcategory = ItemCategory_repo.GetByID(id);
                list.Add(parentcategory);
                while (parentcategory.parentID != null)
                {
                    parentcategory = ItemCategory_repo.GetByID(Convert.ToInt32(parentcategory.parentID));
                    list.Add(parentcategory);
                }
                return Ok(list);
            }
            catch (Exception e)
            {
                logger.LogError("Item Category Get Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Message = "Internal Server Error" });
            }
        }
        [HttpGet("info")]
        public ActionResult<ItemCategory> Get([FromQuery]int id)
        {
            try
            {
                if (ItemCategory_repo.GetByID(id) == null)
                    return NotFound(new ErrorResponse() {Message= "Gategory Not Found" });
                return Ok(ItemCategory_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Item Category Get Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

        // POST api/<ItemCategoryController>
        [HttpPost("add")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> add([FromBody] ItemCategory itemCategory)
        {
            try
            {
                ObjectResult d = VerifyData(itemCategory);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ItemCategory_ValidationError error = (ItemCategory_ValidationError)d.Value;
                    if (error == null)
                    {
                        var category = ItemCategory_repo.Add(itemCategory);
                        return Ok(category);
                    }
                    else
                    {
                        return Conflict(new ErrorResponse() { Message = error.nameError });
                    }

                }
                else
                    return d;

            }
            catch (Exception e)
            {
                logger.LogError("Item Category add Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Message = "Internal Server Error" } );
            }
        }

        [HttpPut("update")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> update( [FromBody] ItemCategory itemCategory)
        {
            try
            {
                var category = ItemCategory_repo.GetByID(itemCategory.Id);
                if(category.name== itemCategory.name)//if same there is no need to call verify data cuz name is unique in parent category
                {
                    ItemCategory_repo.Update(itemCategory);
                    return Ok();
                }
                ObjectResult d = VerifyData(itemCategory);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ItemCategory_ValidationError error = (ItemCategory_ValidationError)d.Value;
                    if (error == null)
                    {
                        ItemCategory_repo.Update(itemCategory);
                        return Ok();
                    }
                    else
                    {
                        return Conflict(new ErrorResponse() { Message = error.nameError });
                    }

                }
                else
                    return d;

            }
            catch (Exception e)
            {
                logger.LogError("Item Category update Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Message =e.Message });
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                if (ItemCategory_repo.List().Where(x => x.parentID == id).Count()>0)
                    return Conflict( "Category Not Empty,Delete Childs First!");
                ItemCategory_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Item Category delete Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse() { Message = "Internal Server Error" });
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(ItemCategory category)
        {
            try
            {
                ItemCategory_ValidationError Error = null;
                if (category.parentID != null)
                    if (ItemCategory_repo.GetByID((int)category.parentID) == null)
                        return StatusCode(StatusCodes.Status400BadRequest,
                            new ErrorResponse() { Message = "Bad Parameters" });

                var oldcategory = ItemCategory_repo.GetByID(category.Id);
                if (oldcategory != null)
                {
                    if (oldcategory.name != category.name)
                    {
                        if (ItemCategory_repo.List().Where(x => x.name == category.name
                            && x.parentID == category.parentID).Count() > 0)
                            Error = new ItemCategory_ValidationError() { nameError = $"Category Name '{category.name}' is already in use." };

                    }
                }
                else
                {
                    if (ItemCategory_repo.List().Where(x => x.name == category.name
                                     && x.parentID == category.parentID).Count() > 0)
                        Error = new ItemCategory_ValidationError() { nameError = $"Category Name '{category.name}' is already in use." };

                }
                return Ok(Error);

            }
            catch (Exception e)
            {
                logger.LogError("Item Category VerifyData:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                    ,new ErrorResponse() { Message = "Internal Server Error" });
            }
        }
    }
}
