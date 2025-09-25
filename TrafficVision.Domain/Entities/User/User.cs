using TrafficVision.Domain.Entities.Base;

namespace TrafficVision.Domain.Entities.User;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public EnumUserRole UserRole { get; private set; }
    public UserEmail UserEmail { get; private set; }
    public UserPassword UserPassword { get; private set; }

    public User(string name, EnumUserRole userRole, UserEmail userEmail, UserPassword userPassword)
    {
        BaseValidate.NullOrWhiteSpace(name, nameof(User));

        Name = name;
        UserRole = userRole;
        UserEmail = userEmail;
        UserPassword = userPassword;
    }
}