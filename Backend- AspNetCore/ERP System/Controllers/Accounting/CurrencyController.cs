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
    [Route("Accounting/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<Currency> Currency_repo;
        public CurrencyController(ILogger<CurrencyController> logger, IApplicationRepository<Currency> Currency_repo)
        {
            this.logger = logger;
            this.Currency_repo = Currency_repo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] Currency currency)
        {
            try
            {
                ObjectResult d = VerifyData(currency);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         Currency_repo.Add(currency);
                        return Ok();
                    }
                    else
                        return Conflict(err) ;
                }
                else
                    return d;
            }
            catch (Exception e)
            {
                logger.LogError("Controller:Currency,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Currency currency)
        {
            try
            {
                ObjectResult d = VerifyData(currency);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         Currency_repo.Update(currency);
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
                logger.LogError("Controller:Currency,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                 Currency_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:Currency,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<Currency>> Info([FromQuery] int id)
        {
            try
            {
                if (id == -1) return Ok(Currency.ReferenceCurrency);
                return Ok(Currency_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:Currency,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<Currency>>> List()
        {
            try
            {
                var currencyies = Currency_repo.List().ToList();
                currencyies.Add(Currency.ReferenceCurrency);
                return Ok(currencyies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:Currency,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(Currency currency)
        {
            try
            {
                string Error = null;

                var oldcurrency = Currency_repo.GetByID(currency.Id);
                if (oldcurrency != null)
                {
                    if (oldcurrency.Name != currency.Name)
                    {
                        if (currency.Name.Length < 1 || currency.Name.Length > 50)
                            Error = "Name must be maximum 50 charecters and minimum 1 charecter ";
                        else if (Currency_repo.List().Where(x => x.Name == currency.Name).Any())
                            Error = $"Currency Name '{currency.Name}' is already in use.";
                    }
                    if (oldcurrency.Symbol != currency.Symbol)
                    {
                        if(currency.Symbol.Length<1 || currency.Symbol.Length>25)
                            Error = "Symbol must be maximum 25 charecters and minimum 1 charecter ";
                        else if (Currency_repo.List().Where(x => x.Symbol == currency.Symbol).Any())
                            Error = $"Symbol  [{ currency.Symbol}] is already in use.";

                    }
                    if (currency.ExchangeRate <= 0)
                        Error = "Exchange Rate Must Be Greater Than Zero";
                }
                else
                {
  		            if(currency.Name.ToLower() == Currency.ReferenceCurrency.Name.ToLower())
                        Error = "Currency Name 'US Dollar' Is Reversed.";
                    else if (currency.Name.Length < 1 || currency.Name.Length > 50)
                        Error = "Name must be maximum 50 charecters and minimum 1 charecter ";
                    else if (Currency_repo.List().Where(x => x.Name.ToLower() == currency.Name.ToLower()).Any())
                        Error = $"Currency Name '{currency.Name}' is already in use.";

		            if (currency.Symbol== Currency.ReferenceCurrency.Symbol)
                        Error = "Currency Symbol'$' Is Reversed.";
                    else if (currency.Symbol.Length < 1 || currency.Symbol.Length > 25)
                        Error = "Symbol must be maximum 25 charecters and minimum 1 charecter ";
                    else if (Currency_repo.List().Where(x => x.Symbol.ToLower() == currency.Symbol.ToLower()).Any())
                        Error = $"Symbol [{ currency.Symbol}] is already in use.";

                    if (currency.ExchangeRate <= 0)
                        Error = "Exchange Rate Must Be Greater Than Zero";
                }
                if (Error == null)
                    return Ok(null);
                else
                    return Ok(new ErrorResponse()
                    { Message = Error});
            }
            catch (Exception e)
            {
                logger.LogError("Currency Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }

    }
}
