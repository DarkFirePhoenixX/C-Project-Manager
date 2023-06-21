using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Shared.Dto;
using ProjectManager.Shared.Interfaces;
using System.Globalization;

namespace ProjectManager.Server.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        public ReportController(IReport reportModel)
        {
            ReportModel = reportModel;
        }

        [Inject]
        protected IReport ReportModel { get; set; }
        [HttpGet("forecast")]
        public async Task<IActionResult> Forecast(
            [FromQuery(Name = "startDate")] string startDate,
            [FromQuery(Name = "endDate")] string endDate,
            [FromQuery(Name = "companyId")] Guid companyId)
        {
            try
            {
                DateTime startDateParsed = DateTime.ParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime endDateParsed = DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                ForecastReportDto forecastReport = await ReportModel.Forecast(startDateParsed, endDateParsed, companyId);
                return Ok(forecastReport);
            }
            catch (Exception e)
            {
                return e switch
                {
                    InvalidDataException => BadRequest(e.Message),
                    FormatException => BadRequest(e.Message),
                    UnauthorizedAccessException => Unauthorized(e.Message),
                    _ => e is DbUpdateException ? BadRequest(e.Message) : StatusCode(500, e)
                };
            }
        }
        [HttpGet("user")]
        public async Task<IActionResult> UserProductivity([FromQuery(Name = "userId")] string userId, [FromQuery(Name = "companyId")] Guid companyId)
        {
            try
            {
                UserProductivityDto userProductivity = await ReportModel.UserProductivity(userId, companyId);
                return Ok(userProductivity);
            }
            catch (Exception e)
            {
                return e switch
                {
                    InvalidDataException => BadRequest(e.Message),
                    FormatException => BadRequest(e.Message),
                    UnauthorizedAccessException => Unauthorized(e.Message),
                    _ => e is DbUpdateException ? BadRequest(e.Message) : StatusCode(500, e)
                };
            }
        }
    }
}
