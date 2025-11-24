using MediatR;
using TrafficVision.Application.Interface;
using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces;
using TrafficVision.Domain.Interfaces.Repository;

namespace TrafficVision.Application.Features.Commands;

public sealed class CreateReportRegistrationCommandHandler : IRequestHandler<CreateReportRegistrationCommand, Result<ReportRegistration>>
{
    private readonly IReportRegistrationService _service;
    private readonly IWriteReportRegistrationRepository _writeReportRegistratonRepository;
    private readonly IReadUserRepository _readUserRepository;
    private readonly IWriteVehicleRepository _writeVehicleRepository;
    private readonly IPlateProcessor _plateProcessor;

    public CreateReportRegistrationCommandHandler(IReportRegistrationService service, IWriteReportRegistrationRepository writeReportRegistratonRepository, IReadUserRepository readUserRepository, IWriteVehicleRepository writeVehicleRepository, IPlateProcessor plateProcessor)
    {
        _service = service;
        _writeReportRegistratonRepository = writeReportRegistratonRepository;
        _readUserRepository = readUserRepository;
        _writeVehicleRepository = writeVehicleRepository;
        _plateProcessor = plateProcessor;
    }

    public async Task<Result<ReportRegistration>> Handle(CreateReportRegistrationCommand request, CancellationToken cancellationToken)
    {
        var result = new Result<ReportRegistration>();

        string finalPlate = request.Plate;

        if (string.IsNullOrWhiteSpace(finalPlate) && request.File != null && request.File.Length > 0)
        {
            finalPlate = await _plateProcessor.RecognizePlateAsync(request.File);

            if (string.IsNullOrEmpty(finalPlate))
                return result.ExternalError("Não foi possível identificar nenhuma placa na imagem enviada.");
        }

        if (string.IsNullOrWhiteSpace(finalPlate))
            return result.ExternalError("A placa é obrigatória (informe o texto ou envie uma imagem legível).");

        finalPlate = finalPlate.ToUpper().Trim().Replace("-", "");

        var user = await _readUserRepository.GetByIdAsync(request.UserId);

        if (user == null)
            return result.ExternalError($"Usuário não encontrado, efetue o login corretamente");

        var vehicleDTO = await _service.GetByPlateAsync(finalPlate, cancellationToken);

        if (vehicleDTO == null)
            return result.ExternalError($"Nenhum veículo encontrado com a placa: {finalPlate}");

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

        var createdVehicle = await _writeVehicleRepository.AddAsync(validatedVehicle);

        var createdReportRegistration = ReportRegistration.Create(user.Id, createdVehicle.Id);

        await _writeReportRegistratonRepository.AddAsync(createdReportRegistration);

        return result.Success(createdReportRegistration);
    }
}