﻿using ERP_System.Models.Materials;
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
        private readonly IApplicationRepository<ItemCategory> repo;
        private readonly ILogger logger;
        public ItemCategoryController(IApplicationRepository<ItemCategory> repo,ILogger<ItemCategoryController> _logger)
        {
            this.repo = repo;
            logger = _logger;
        }

        
        [HttpGet("GetCategories")]
        public async Task<ActionResult<IEnumerable<ItemCategory>>> GetCategories([FromQuery] int? parentid)
        { 
            try
            {
                if(parentid!=null)
                    if (repo.GetByID((int)parentid) == null) return NotFound();
                return Ok(repo.List().Where(x=>x.ParentID==parentid).ToList());

            }
            catch (Exception e)
            {
                logger.LogError("Item Category GetCategories Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("info")]
        public ActionResult<ItemCategory> Get([FromQuery]int id)
        {
            try
            {
                if (repo.GetByID(id) == null) return NotFound();
                return Ok(repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Item Category Get Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        // POST api/<ItemCategoryController>
        [HttpPost("add")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> add([FromBody] ItemCategory itemCategory)
        {
            logger.LogInformation("add");
            try
            {
                repo.Add(itemCategory);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Item Category add Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> update([FromQuery] int id, [FromBody] ItemCategory itemCategory)
        {
            try
            {
                if(repo.GetByID(id)==null) return NotFound();
                itemCategory.ID = id;
                repo.Update(itemCategory);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Item Category update Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                if (repo.GetByID(id) == null) return NotFound();
                repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Item Category delete Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}