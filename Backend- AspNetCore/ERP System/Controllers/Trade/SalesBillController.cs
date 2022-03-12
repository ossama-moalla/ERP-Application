using ERP_System.Models.Trade;
using ERP_System.Models.Trade.Reports.SalesBillsReport;
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
    public class SalesBillController : ControllerBase
    {


        private readonly ILogger logger;
        private readonly IApplicationRepository<SalesBill> SalesBill_repo;
        private readonly IReportByDateTypeRepository<SalesBill, SalesBillsReport_DayReport, SalesBillsReport_MonthReport
                , SalesBillsReport_YearReport, SalesBillsReport_YearRangeReport> SalesBillReport_repo;
        public SalesBillController(ILogger<SalesBillController> logger
            , IApplicationRepository<SalesBill> SalesBill_repo, IReportByDateTypeRepository<SalesBill, SalesBillsReport_DayReport, SalesBillsReport_MonthReport
                , SalesBillsReport_YearReport, SalesBillsReport_YearRangeReport> SalesBillReport_repo)
        {
            this.logger = logger;
            this.SalesBill_repo = SalesBill_repo;
            this.SalesBillReport_repo = SalesBillReport_repo;
        }
        [HttpPut("Add")]
        public async Task<ActionResult> Add([FromBody] SalesBill SalesBill)
        {
            try
            {
                ObjectResult d = VerifyData(SalesBill);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         SalesBill_repo.Add(SalesBill);
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
                logger.LogError("Controller:SalesBill,Method:Add,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] SalesBill SalesBill)
        {
            try
            {
                ObjectResult d = VerifyData(SalesBill);
                if (d.StatusCode == StatusCodes.Status200OK)
                {
                    ErrorResponse err = (ErrorResponse)d.Value;
                    if (err == null)
                    {
                         SalesBill_repo.Update(SalesBill);
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
                logger.LogError("Controller:SalesBill,Method:Update,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                 SalesBill_repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SalesBill,Method:Delete,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("Info")]
        public async Task<ActionResult<SalesBill>> Info([FromQuery] int id)
        {
            try
            {
                return Ok(SalesBill_repo.GetByID(id));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SalesBill,Method:Info,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<SalesBill>>> List()
        {
            try
            {
                var SalesBillies = SalesBill_repo.List().ToList();
                return Ok(SalesBillies);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SalesBill,Method:List,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("DealerSalesBills")]
        public async Task<ActionResult<IEnumerable<SalesBill_Report>>> DealerSalesBills([FromQuery] int dealerId)
        {
            try
            {
                var SalesBills = SalesBill_repo.List().Where(x => x.DealerId == dealerId).ToList();
                var returnlist = new List<SalesBill_Report>();
                foreach(var salesbill in SalesBills)
                {
                    returnlist.Add(salesbill.Convert_To_SalesBill_Report());
                }
                return Ok(returnlist);
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SalesBill,Method:DealerSalesBills,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpPost("verifydata")]
        public ObjectResult VerifyData(SalesBill SalesBill)
        {
            try
            {
                return Ok(null);
            }
            catch (Exception e)
            {
                logger.LogError("SalesBill Controller- VerifyDataError:" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError
                                    , new ErrorResponse() { Message = "Internal Server Error" });
            }
        }
        [HttpGet("day_report")]
        public ActionResult<SalesBill_Report> DayReport([FromQuery] int year, [FromQuery] int month, [FromQuery] int day)
        {
            try
            {
                var SalesBillsList = SalesBill_repo.List().ToList();
                return Ok(this.SalesBillReport_repo.DayReport(SalesBillsList, year, month, day));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SalesBillsController,Method:DayReport,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("month_report")]
        public ActionResult<SalesBillsReport_InDay> MonthReport([FromQuery] int year, [FromQuery] int month)
        {
            try
            {
                var SalesBillsList = SalesBill_repo.List().ToList();
                return Ok(this.SalesBillReport_repo.MonthReport(SalesBillsList, year, month));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SalesBillsController,Method:MonthReport,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("year_report")]
        public ActionResult<SalesBillsReport_InMonth> YearReport([FromQuery] int year)
        {
            try
            {
                var SalesBillsList = SalesBill_repo.List().ToList();
                return Ok(this.SalesBillReport_repo.YearReport(SalesBillsList, year));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SalesBillsController,Method:YearReport,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
        [HttpGet("year_range_report")]
        public ActionResult<SalesBillsReport_InYear> YearRangeReport([FromQuery] int year1, [FromQuery] int year2)
        {
            try
            {
                var SalesBillsList = SalesBill_repo.List().ToList();
                return Ok(this.SalesBillReport_repo.YearRangeReport(SalesBillsList, year1, year2));
            }
            catch (Exception e)
            {
                logger.LogError("Controller:SalesBillsController,Method:YearRangeReport,Error:" + e.Message);
                return LocalException.HanldeException(e);
            }
        }
    }

}
