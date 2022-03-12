using ERP_System.Models.Trade;
using ERP_System.Models.Trade.Reports.PurchasesBillsReport;
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
    public class PurchasesBillController : ControllerBase
    {

        private readonly ILogger logger;
        private readonly IApplicationRepository<PurchasesBill> PurchasesBill_repo;
        private readonly IReportByDateTypeRepository<PurchasesBill, PurchasesBillsReport_DayReport, PurchasesBillsReport_MonthReport
                , PurchasesBillsReport_YearReport, PurchasesBillsReport_YearRangeReport> PurchasesBillReport_repo;
        public PurchasesBillController(ILogger<PurchasesBillController> logger, 
            IApplicationRepository<PurchasesBill> PurchasesBill_repo, IReportByDateTypeRepository<PurchasesBill, PurchasesBillsReport_DayReport, PurchasesBillsReport_MonthReport
                , PurchasesBillsReport_YearReport, PurchasesBillsReport_YearRangeReport> PurchasesBillReport_repo)
        {
            this.logger = logger;
            this.PurchasesBill_repo = PurchasesBill_repo;
            this.PurchasesBillReport_repo = PurchasesBillReport_repo;
        }
        [HttpPut("Add")]
        public async Task<ActionResult> Add([FromBody] PurchasesBill PurchasesBill)
        {
            try
            {
                ObjectResult d = VerifyData(PurchasesBill);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                          PurchasesBill_repo.Add(PurchasesBill);
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
                logger.LogError("Controller:PurchasesBill,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] PurchasesBill PurchasesBill)
        {
            try
            {
                ObjectResult d = VerifyData(PurchasesBill);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         PurchasesBill_repo.Update(PurchasesBill);
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
                logger.LogError("Controller:PurchasesBill,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                 PurchasesBill_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PurchasesBill,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<PurchasesBill>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(PurchasesBill_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PurchasesBill,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<PurchasesBill>>> List()
        {
            try
            {
                var PurchasesBillies = PurchasesBill_repo.List().ToList();
                return Ok(PurchasesBillies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PurchasesBill,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("DealerPurchasesBills")]
        public async Task<ActionResult<IEnumerable<PurchasesBill>>> DealerPurchasesBills([FromQuery] int dealerId)
        {
            try
            {
                var PurchasesBillies = PurchasesBill_repo.List().Where(x=>x.DealerId== dealerId).ToList();
                return Ok(PurchasesBillies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PurchasesBill,Method:DealerPurchasesBills,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(PurchasesBill PurchasesBill)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("PurchasesBill Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }
        [HttpGet("day_report")]
        public ActionResult<PurchasesBill_Report> DayReport([FromQuery] int year, [FromQuery] int month, [FromQuery] int day)
        {
            try
            {
                var PurchasesBillsList = PurchasesBill_repo.List().ToList();
                return Ok(this.PurchasesBillReport_repo.DayReport(PurchasesBillsList,year, month, day));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PurchasesBillsController,Method:DayReport,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("month_report")]
        public ActionResult<PurchasesBillsReport_InDay> MonthReport([FromQuery] int year, [FromQuery] int month)
        {
            try
            {
                var PurchasesBillsList = PurchasesBill_repo.List().ToList();
                return Ok(this.PurchasesBillReport_repo.MonthReport(PurchasesBillsList, year, month));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PurchasesBillsController,Method:MonthReport,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("year_report")]
        public ActionResult<PurchasesBillsReport_InMonth> YearReport([FromQuery] int year)
        {
            try
            {
                var PurchasesBillsList = PurchasesBill_repo.List().ToList();
                return Ok(this.PurchasesBillReport_repo.YearReport(PurchasesBillsList, year));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PurchasesBillsController,Method:YearReport,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("year_range_report")]
        public ActionResult<PurchasesBillsReport_InYear> YearRangeReport([FromQuery] int year1, [FromQuery] int year2)
        {
            try
            {
                var PurchasesBillsList = PurchasesBill_repo.List().ToList();
                return Ok(this.PurchasesBillReport_repo.YearRangeReport(PurchasesBillsList, year1,year2));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:PurchasesBillsController,Method:YearRangeReport,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }

    }

}
