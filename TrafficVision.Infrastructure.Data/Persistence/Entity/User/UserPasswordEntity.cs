using TrafficVision.Domain.Entities.Base;

namespace TrafficVision.Infrastructure.Data.Persistence.Entity;

public sealed class UserPassword
{
    #region Property
    public string Value { get; private set; }
    #endregion

    #region Constructors
    public UserPassword() { }

    public UserPassword(string value)
    {
        Value = value;
    }
    #endregion
}