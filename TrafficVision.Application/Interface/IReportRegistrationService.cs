using TrafficVision.Application.DTOs;

namespace TrafficVision.Application.Interface;

public interface IReportRegistrationService
{
    Task<VehicleDTO?> GetByPlateAsync(string plate, CancellationToken cancellationToken);
}
