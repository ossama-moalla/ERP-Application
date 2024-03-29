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
    public class InternalConsumeController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<InternalConsume> InternalConsume_repo;
        public InternalConsumeController(ILogger<InternalConsumeController> logger, IApplicationRepository<InternalConsume> InternalConsume_repo)
        {
            this.logger = logger;
            this.InternalConsume_repo = InternalConsume_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] InternalConsume InternalConsume)
        {
            try
            {
                ObjectResult d = VerifyData(InternalConsume);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         InternalConsume_repo.Add(InternalConsume);
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
                logger.LogError("Controller:InternalConsume,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] InternalConsume InternalConsume)
        {
            try
            {
                ObjectResult d = VerifyData(InternalConsume);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         InternalConsume_repo.Update(InternalConsume);
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
                logger.LogError("Controller:InternalConsume,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                 InternalConsume_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:InternalConsume,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<InternalConsume>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(InternalConsume_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:InternalConsume,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<InternalConsume>>> List()
        {
            try
            {
                var InternalConsumeies = InternalConsume_repo.List().ToList();
                return Ok(InternalConsumeies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:InternalConsume,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(InternalConsume InternalConsume)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("InternalConsume Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}
