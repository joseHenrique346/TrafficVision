namespace TrafficVision.Infrastructure.Data.Persistence.Entity;

public sealed class UserEntity : BaseEntity
{
    #region Properties
    public string Name { get; private set; }
    public EnumUserRole UserRole { get; private set; }
    public UserEmail UserEmail { get; private set; }
    public UserPassword UserPassword { get; private set; }
    #endregion

    #region Constructors
    public UserEntity() { }

    public UserEntity(string name, EnumUserRole userRole, UserEmail userEmail, UserPassword userPassword)
    {
        Name = name;
        UserRole = userRole;
        UserEmail = userEmail;
        UserPassword = userPassword;
    }
    #endregion
}