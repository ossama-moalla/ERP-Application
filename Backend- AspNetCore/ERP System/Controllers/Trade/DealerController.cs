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
    public class DealerController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<Dealer> Dealer_repo;
        public DealerController(ILogger<DealerController> logger, IApplicationRepository<Dealer> Dealer_repo)
        {
            this.logger = logger;
            this.Dealer_repo = Dealer_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] Dealer Dealer)
        {
            try
            {
                ObjectResult d = VerifyData(Dealer);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         Dealer_repo.Add(Dealer);
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
                logger.LogError("Controller:Dealer,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Dealer Dealer)
        {
            try
            {
                ObjectResult d = VerifyData(Dealer);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         Dealer_repo.Update(Dealer);
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
                logger.LogError("Controller:Dealer,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                Dealer_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:Dealer,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<Dealer>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(Dealer_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:Dealer,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<Dealer>>> List()
        {
            try
            {
                var Dealeries = Dealer_repo.List().ToList();
                return Ok(Dealeries);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:Dealer,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(Dealer Dealer)
        {
            try
            {

                var olddealer = Dealer_repo.GetByID(Dealer.Id);
                if (olddealer != null)
                {
                    if (olddealer.FullName != Dealer.FullName && Dealer_repo.List().Where(x => x.FullName == Dealer.FullName).Any())
                        return Ok(new ErrorResponse() { Message = $"DealerFull Name '{Dealer.FullName}' is already in use." });
                }
                else
                {
                    if (Dealer_repo.List().Where(x => x.FullName == Dealer.FullName).Any())
                        return Ok(new ErrorResponse() { Message = $"DealerFull Name '{Dealer.FullName}' is already in use." });
                }
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("Dealer Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }

}

