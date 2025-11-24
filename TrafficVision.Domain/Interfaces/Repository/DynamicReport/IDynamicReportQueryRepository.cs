using TrafficVision.Domain.Entities;

namespace TrafficVision.Domain.Interfaces.Repository;

public interface IDynamicReportQueryRepository
{
    Task<IEnumerable<Vehicle>> QueryAsync(DynamicReport filter, CancellationToken cancellationToken);
}
