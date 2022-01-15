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
                    Currency_ValidationError err = (Currency_ValidationError)d.Value;
                    if (err == null)
                    {
                        Currency_repo.Add(currency);
                        return Ok();
                    }
                    else
                        return Conflict(new ErrorResponse() { Message = err.ConvertToString() }) ;
                }
                else
                    return d;
            }
            catch (Exception e)
            {
                logger.LogError("Controller:Currency,Method:Add,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
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
                    Currency_ValidationError err = (Currency_ValidationError)d.Value;
                    if (err == null)
                    {
                        Currency_repo.Update(currency);
                        return Ok();
                    }
                    else
                        return Conflict(new ErrorResponse() { Message = err.ConvertToString() });

                }
                else
                    return d;
            }
            catch (Exception e)
            {
                logger.LogError("Controller:Currency,Method:Update,Error:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(Currency currency)
        {
            try
            {
                string nameError = null, symbolError = null,exchangeRateError=null;
                if (currency.Name == Currency.ReferenceCurrency.Name || currency.Symbol == Currency.ReferenceCurrency.Symbol)
                {
                    if(currency.Name.ToLower() == Currency.ReferenceCurrency.Name.ToLower())
                        nameError = "Currency Name 'US Dollar' Is Reversed.";
                    if (currency.Symbol== Currency.ReferenceCurrency.Symbol)
                        nameError = "Currency Symbol $ Is Reversed.";
                    return Ok(new Currency_ValidationError()
                        { nameError = nameError, symbolError = symbolError, exchangeRateError = exchangeRateError });

                }

                var oldcurrency = Currency_repo.GetByID(currency.Id);
                if (oldcurrency != null)
                {
                    if (oldcurrency.Name.ToLower() != currency.Name.ToLower())
                    {
                        if (Currency_repo.List().Where(x => x.Name.ToLower() == currency.Name.ToLower()).Count() > 0)
                            nameError = $"Currency Name '{currency.Name}' is already in use.";
                    }
                    if (oldcurrency.Symbol.ToLower() != currency.Symbol.ToLower())
                    {
                        if (Currency_repo.List().Where(x => x.Symbol == currency.Symbol).Count() > 0)
                            symbolError = $"Index [{ currency.Symbol}] is already in use.";

                    }
                    if (currency.ExchangeRate <= 0)
                        exchangeRateError = "Exchange Rate Must Be Greater Than Zero";
                }
                else
                {
                    if (Currency_repo.List().Where(x => x.Name.ToLower() == currency.Name.ToLower()).Count() > 0)
                        nameError = $"Currency Name '{currency.Name}' is already in use.";
                    if (Currency_repo.List().Where(x => x.Symbol.ToLower() == currency.Symbol.ToLower()).Count() > 0)
                        symbolError = $"Index [{ currency.Symbol}] is already in use.";
                    if (currency.ExchangeRate <= 0)
                        exchangeRateError = "Exchange Rate Must Be Greater Than Zero";
                }
                if (nameError == null && symbolError == null&& exchangeRateError==null)
                    return Ok(null);
                else
                    return Ok(new Currency_ValidationError()
                    { nameError = nameError, symbolError = symbolError,exchangeRateError=exchangeRateError });
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
