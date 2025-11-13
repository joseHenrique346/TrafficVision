using TrafficVision.Domain.Entities.Base;

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
        BaseValidate.NullOrWhiteSpace(name, nameof(UserEntity));

        Name = name;
        UserRole = userRole;
        UserEmail = userEmail;
        UserPassword = userPassword;
    }
    #endregion

    #region Create/Update
    public static UserEntity Create(string name, EnumUserRole userRole, string userEmail, string userPassword)
    {
        return new UserEntity(name, userRole, UserEmail.Create(userEmail), UserPassword.Create(userPassword));
    }

    public void Update(string name, EnumUserRole userRole, UserEmail userEmail, UserPassword userPassword)
    {
        BaseValidate.NullOrWhiteSpace(name, nameof(UserEntity));

        Name = name;
        UserRole = userRole;
        UserEmail = userEmail;
        UserPassword = userPassword;

        SetChangedDate();
    }
    #endregion
}