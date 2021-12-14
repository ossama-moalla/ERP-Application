﻿using ERP_System.Models.Materials;
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
                ContentResult d = VerifyData(CategorySpec);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ItemCategorySpec_Repo.Add(CategorySpec);
                    return Ok();
                }
                else
                    return Conflict(d.Content);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,e);
            }
        }
        [HttpPut("update")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult Update(ItemCategorySpec CategorySpec)
        {
            try
            {
                ContentResult d = VerifyData(CategorySpec);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ItemCategorySpec_Repo.Update(CategorySpec);
                    return Ok();
                }
                else
                    return Conflict(d.Content);
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
        [HttpGet("verifydata")]
        private ContentResult VerifyData(ItemCategorySpec categoryspec)
        {
            if (ItemCategorySpec_Repo.List().Where(x => x.name == categoryspec.name
                 && x.CategoryID == categoryspec.CategoryID).Count() > 0)
                return new ContentResult() { Content = $"SpecName: {categoryspec.name} is already in use.", StatusCode = StatusCodes.Status409Conflict };

            if (ItemCategorySpec_Repo.List().Where(x => x.index == categoryspec.index
                && x.CategoryID == categoryspec.CategoryID).Count() > 0)
                return new ContentResult() { Content = $"Index: { categoryspec.index} is already in use.", StatusCode = StatusCodes.Status409Conflict };

            return new ContentResult() { Content = "ok", StatusCode = StatusCodes.Status200OK };
        }
    }
}
