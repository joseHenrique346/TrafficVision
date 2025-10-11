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
}