using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;
using TrafficVision.Infrastructure.Data.Persistence;

namespace TrafficVision.Infrastructure.Data.Repository;

public class WriteDynamicReportRepository(AppDbContext context) : WriteBaseRepository<DynamicReport>(context), IWriteDynamicReportRepository { }