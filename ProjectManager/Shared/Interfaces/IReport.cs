using ProjectManager.Shared.Dto;

namespace ProjectManager.Shared.Interfaces
{
    public interface IReport
    {
        Task<ForecastReportDto> Forecast(DateTime startDate, DateTime endDate, Guid companyId);
        Task<UserProductivityDto> UserProductivity(string userId, Guid companyId);
    }
}
