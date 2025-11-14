using TrafficVision.Application.DTOs;
using TrafficVision.Application.Interface;
using VehicleAPI.Grpc;

namespace TrafficVision.Api.Service;

public class ReportRegistrationService : IReportRegistrationService
{
    private readonly VehicleService.VehicleServiceClient _client;

    public ReportRegistrationService(VehicleService.VehicleServiceClient client)
    {
        _client = client;
    }

    public async Task<VehicleDTO?> GetByPlateAsync(string plate, CancellationToken cancellationToken)
    {
        var request = new VehicleByPlateRequest { Plate = plate };

        var response = await _client.GetVehicleByPlateAsync(request, cancellationToken: cancellationToken);

        if (string.IsNullOrEmpty(response.Plate))
            return null;

        return new VehicleDTO
        {
            Plate = response.Plate,
            Brand = response.Brand,
            Model = response.Model,
            Year = response.Year,
            Color = response.Color,
            Renavam = response.Renavam,
            Chassis = response.Chassis,
            Municipality = response.Municipality,
            State = response.State,

            EnumDataVehicleCondition = (EnumDataVehicleCondition)Convert.ToInt32(response.VehicleCondition),
            FuelType = (EnumTypeFuelVehicle)Convert.ToInt32(response.FuelType),
            TheftVehicleCondition = (EnumTheftVehicleCondition)Convert.ToInt32(response.TheftCondition),

            Wrecked = response.Wrecked,
            JudicialRestriction = response.JudicialRestriction,
            Auction = response.Auction,
            OwnerName = response.OwnerName,
            OwnerCpfCnpj = response.OwnerCpfCnpj,
            OwnerCnh = response.OwnerCnh,
        };

    }
}
