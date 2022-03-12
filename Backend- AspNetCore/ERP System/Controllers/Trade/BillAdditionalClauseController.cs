using ERP_System.Models.Trade;
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
    public class BillAdditionalClauseController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<BillAdditionalClause> BillAdditionalClause_repo;
        public BillAdditionalClauseController(ILogger<BillAdditionalClauseController> logger, IApplicationRepository<BillAdditionalClause> BillAdditionalClause_repo)
        {
            this.logger = logger;
            this.BillAdditionalClause_repo = BillAdditionalClause_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] BillAdditionalClause BillAdditionalClause)
        {
            try
            {
                ObjectResult d = VerifyData(BillAdditionalClause);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         BillAdditionalClause_repo.Add(BillAdditionalClause);
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
                logger.LogError("Controller:BillAdditionalClause,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] BillAdditionalClause BillAdditionalClause)
        {
            try
            {
                ObjectResult d = VerifyData(BillAdditionalClause);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         BillAdditionalClause_repo.Update(BillAdditionalClause);
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
                logger.LogError("Controller:BillAdditionalClause,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                 BillAdditionalClause_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:BillAdditionalClause,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<BillAdditionalClause>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(BillAdditionalClause_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:BillAdditionalClause,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<BillAdditionalClause>>> List()
        {
            try
            {
                var BillAdditionalClauseies = BillAdditionalClause_repo.List().ToList();
                return Ok(BillAdditionalClauseies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:BillAdditionalClause,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(BillAdditionalClause BillAdditionalClause)
        {
            try
            {
                if (BillAdditionalClause.Value <= 0) 
                    return Ok(new ErrorResponse() { Message = "Value must be Greater than Zero" });
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("BillAdditionalClause Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}
