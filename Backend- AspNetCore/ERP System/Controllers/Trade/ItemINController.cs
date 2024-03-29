﻿using ERP_System.Models.Trade;
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
    public class ItemINController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<ItemIN> ItemIN_repo;
        public ItemINController(ILogger<ItemINController> logger, IApplicationRepository<ItemIN> ItemIN_repo)
        {
            this.logger = logger;
            this.ItemIN_repo = ItemIN_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] ItemIN ItemIN)
        {
            try
            {
                ObjectResult d = VerifyData(ItemIN);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         ItemIN_repo.Add(ItemIN);
                        return Ok();
                    }
                    else
                        return BadRequest(err);
                }
                else
                    return d;
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemIN,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] ItemIN ItemIN)
        {
            try
            {
                ObjectResult d = VerifyData(ItemIN);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         ItemIN_repo.Update(ItemIN);
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
                logger.LogError("Controller:ItemIN,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                 ItemIN_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemIN,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<ItemIN>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(ItemIN_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemIN,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<ItemIN>>> List()
        {
            try
            {
                var ItemINies = ItemIN_repo.List().ToList();
                return Ok(ItemINies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:ItemIN,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(ItemIN ItemIN)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("ItemIN Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}
