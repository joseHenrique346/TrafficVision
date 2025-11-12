using TrafficVision.Domain.Entities;

namespace TrafficVision.Domain.Interfaces.Repository;

public interface IReportRegistrationRepository
{
    Task<ReportRegistration> GetByIdAsync(long id);
    Task AddAsync(ReportRegistration report);
}