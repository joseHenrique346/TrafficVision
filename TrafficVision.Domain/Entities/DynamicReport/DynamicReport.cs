using TrafficVision.Domain.Entities.Base;

namespace TrafficVision.Domain.Entities;

public sealed class DynamicReport
{
    #region Properties
    public long UserId { get; private set; }
    public long VehicleId { get; private set; }
    public User? User { get; private set; }
    public Vehicle? Vehicle { get; private set; }
    #endregion

    #region Constructors
    public DynamicReport() { }

    public DynamicReport(long userId, long vehicleId, User? user, Vehicle? vehicle)
    {
        UserId = userId;
        VehicleId = vehicleId;
        User = user;
        Vehicle = vehicle;
    }
    #endregion

    public static DynamicReport Create(long userId, long vehicleId)
    {
        var validatedUserId = userId != null ? userId : 0;
        var validatedVehicleId = vehicleId != null ? vehicleId : 0;

        return new DynamicReport(userId, vehicleId, default, default);
    }
}