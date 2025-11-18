using MediatR;
using TrafficVision.Application.Interface;
using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;

namespace TrafficVision.Application.Features.Commands;

public sealed class CreateReportRegistrationCommandHandler : IRequestHandler<CreateReportRegistrationCommand, Result<ReportRegistration>>
{
    private readonly IReportRegistrationService _service;
    private readonly IWriteReportRegistrationRepository _writeReportRegistratonRepository;
    private readonly IReadUserRepository _readUserRepository;

    public CreateReportRegistrationCommandHandler(IReportRegistrationService service, IWriteReportRegistrationRepository writeReportRegistratonRepository, IReadUserRepository readUserRepository)
    {
        _service = service;
        _writeReportRegistratonRepository = writeReportRegistratonRepository;
        _readUserRepository = readUserRepository;
    }

    public async Task<Result<ReportRegistration>> Handle(CreateReportRegistrationCommand request, CancellationToken cancellationToken)
    {
        var result = new Result<ReportRegistration>();

        var user = await _readUserRepository.GetByIdAsync(request.UserId);

        if (user == null)
            result.Failure($"Usuário não encontrado, efetue o login corretamente");

        var vehicleDTO = await _service.GetByPlateAsync(request.Plate, cancellationToken);

        if (vehicleDTO == null)
            result.Failure($"Nenhum veículo encontrado com a placa: {request.Plate}");

        if (result.IsSuccess == false)
            return result;

        var validatedVehicleRestriction = VehicleRestriction.Create(
            vehicleDTO.TheftVehicleCondition, 
            vehicleDTO.Wrecked, 
            vehicleDTO.JudicialRestriction, 
            vehicleDTO.Auction);

        var validatedVehicleOwner = VehicleOwner.Create(
            vehicleDTO.OwnerName, 
            vehicleDTO.OwnerCpfCnpj, 
            vehicleDTO.OwnerCnh);

        var validatedVehicleSpec = VehicleSpec.Create(
            vehicleDTO.Plate,
            vehicleDTO.Renavam, 
            vehicleDTO.Chassis, 
            vehicleDTO.Municipality, 
            vehicleDTO.State, 
            vehicleDTO.EnumDataVehicleCondition, 
            vehicleDTO.FuelType, 
            validatedVehicleRestriction, 
            validatedVehicleOwner);

        var validatedVehicle = Vehicle.Create(
            vehicleDTO.Model, 
            vehicleDTO.Year, 
            vehicleDTO.Brand, 
            vehicleDTO.Color,
            validatedVehicleSpec);

        var createdReportRegistration = ReportRegistration.Create(user.Id, validatedVehicle.Id);

        await _writeReportRegistratonRepository.AddAsync(createdReportRegistration);

        return result.Success(createdReportRegistration);
    }
}