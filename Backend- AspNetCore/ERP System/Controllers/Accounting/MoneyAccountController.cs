using ERP_System.Models.Accounting;
using ERP_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Controllers.Accounting
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyAccountController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<MoneyAccount> MoneyAccount_repo;
        public MoneyAccountController(ILogger<MoneyAccountController> logger, IApplicationRepository<MoneyAccount> MoneyAccount_repo)
        {
            this.logger = logger;
            this.MoneyAccount_repo = MoneyAccount_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] MoneyAccount MoneyAccount)
        {
            try
            {
                ObjectResult d = VerifyData(MoneyAccount);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        MoneyAccount_repo.Add(MoneyAccount);
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
                logger.LogError("Controller:MoneyAccount,Method:Add,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] MoneyAccount MoneyAccount)
        {
            try
            {
                ObjectResult d = VerifyData(MoneyAccount);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                        MoneyAccount_repo.Update(MoneyAccount);
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
                logger.LogError("Controller:MoneyAccount,Method:Update,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                MoneyAccount_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccount,Method:Delete,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<MoneyAccount>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(MoneyAccount_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccount,Method:Info,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<MoneyAccount>>> List([FromQuery] int CategoryID)
        {
            try
            {
                return Ok(MoneyAccount_repo.List().ToList());
            }
            catch (Exception e)
            {
                logger.LogError("Controller:MoneyAccount,Method:List,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(MoneyAccount MoneyAccount)
        {
            try
            {
                var oldmoneyaccount = MoneyAccount_repo.GetByID(MoneyAccount.Id);
                if (oldmoneyaccount != null)
                {
                    if (oldmoneyaccount.Name != MoneyAccount.Name)
                    {

                        if (MoneyAccount_repo.List().Where(x => x.Name == MoneyAccount.Name).Count() > 0)
                            return Ok(new ErrorResponse()
                            { Message = $"Money Account Name :{MoneyAccount.Name} is already in use!" });
                    }
                }
                else 
                {
                    if (MoneyAccount_repo.List().Where(x => x.Name == MoneyAccount.Name).Count() > 0)
                        return Ok(new ErrorResponse()
                        { Message = $"Money Account Name :{MoneyAccount.Name} is already in use!" });   
                }
                return Ok(null);

            }
            catch (Exception e)
            {
                logger.LogError("MoneyAccount Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }
    }
}
