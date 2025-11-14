namespace TrafficVision.Infrastructure.Data.Persistence.Entity;

public sealed class UserEmail
{
    #region Property
    public string Value { get; private set; }
    #endregion

    #region Constructors
    public UserEmail() { }

    public UserEmail(string value)
    {
        Value = value;
    }
    #endregion
}