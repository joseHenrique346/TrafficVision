using TrafficVision.Domain.Entities;

namespace TrafficVision.Application.DTOs;

public class VehicleDTO
{
    public long Id { get; set; }
    public string Plate { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int Year { get; set; }
    public string Color { get; set; } = null!;
    public string Renavam { get; set; } = null!;
    public string Chassis { get; set; } = null!;
    public string Municipality { get; set; } = null!;
    public string State { get; set; } = null!;
    public EnumDataVehicleCondition EnumDataVehicleCondition { get; set; }
    public EnumTypeFuelVehicle FuelType { get; set; }
    public EnumTheftVehicleCondition TheftVehicleCondition { get; set; }
    public bool Wrecked { get; set; }
    public bool JudicialRestriction { get; set; }
    public bool Auction { get; set; }
    public string OwnerName { get; set; }
    public string OwnerCpfCnpj { get; set; }
    public string OwnerCnh { get; set; }
}
