namespace TrafficVision.Domain.Entities;

public sealed class ReportRegistration
{
    #region Properties
    public long UserId { get; private set; }
    public long VehicleId { get; private set; }
    public User? User { get; private set; }
    public Vehicle? Vehicle { get; private set; }
    #endregion

    #region Constructors
    public ReportRegistration() { }

    public ReportRegistration(long userId, long vehicleId, User? user, Vehicle? vehicle)
    {
        UserId = userId;
        VehicleId = vehicleId;
        User = user;
        Vehicle = vehicle;
    }
    #endregion

    public static ReportRegistration Create(long userId, long vehicleId)
    {
        var validatedUserId = userId != null ? userId : 0;
        var validatedVehicleId = vehicleId != null ? vehicleId : 0;

        return new ReportRegistration(userId, vehicleId, default, default);
    }
}