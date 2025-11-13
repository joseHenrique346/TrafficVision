using TrafficVision.Domain.Entities.Base;

namespace TrafficVision.Infrastructure.Data.Persistence.Entity;

public sealed class User : BaseEntity
{
    #region Properties
    public string Name { get; private set; }
    public EnumUserRole UserRole { get; private set; }
    public UserEmail UserEmail { get; private set; }
    public UserPassword UserPassword { get; private set; }
    #endregion

    #region Constructors
    public User() { }

    public User(string name, EnumUserRole userRole, UserEmail userEmail, UserPassword userPassword)
    {
        BaseValidate.NullOrWhiteSpace(name, nameof(User));

        Name = name;
        UserRole = userRole;
        UserEmail = userEmail;
        UserPassword = userPassword;
    }
    #endregion

    #region Create/Update
    public static User Create(string name, EnumUserRole userRole, string userEmail, string userPassword)
    {
        return new User(name, userRole, UserEmail.Create(userEmail), UserPassword.Create(userPassword));
    }

    public void Update(string name, EnumUserRole userRole, UserEmail userEmail, UserPassword userPassword)
    {
        BaseValidate.NullOrWhiteSpace(name, nameof(User));

        Name = name;
        UserRole = userRole;
        UserEmail = userEmail;
        UserPassword = userPassword;

        SetChangedDate();
    }
    #endregion
}