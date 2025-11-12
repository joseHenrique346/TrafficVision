namespace TrafficVision.Infrastructure.Data.Persistence;

public sealed class ReportRegistrationEntity : BaseEntity
{
    public long UserId { get; private set; }
    public long VehicleId { get; private set; }
    public UserEntity? User { get; private set; }
    public VehicleEntity? Vehicle { get; private set; }

    public ReportRegistrationEntity() { }

    public ReportRegistrationEntity(long userId, long vehicleId, UserEntity? user, VehicleEntity? vehicle)
    {
        UserId = userId;
        VehicleId = vehicleId;
        User = user;
        Vehicle = vehicle;
    }
}
