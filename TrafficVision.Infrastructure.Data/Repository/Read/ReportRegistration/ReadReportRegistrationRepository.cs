using TrafficVision.Domain.Entities;
using TrafficVision.Infrastructure.Data.Persistence;

namespace TrafficVision.Infrastructure.Data.Repository;

public class ReadReportRegistrationRepository(AppDbContext context) : ReadBaseRepository<ReportRegistration>(context) { }