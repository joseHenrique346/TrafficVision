using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;
using TrafficVision.Infrastructure.Data.Persistence;

namespace TrafficVision.Infrastructure.Data.Repository;

public class WriteReportRegistrationRepository(AppDbContext context) : WriteBaseRepository<ReportRegistration>(context), IWriteReportRegistrationRepository { }