using System.Net.Mail;
using TrafficVision.Domain.Entities.Base;

namespace TrafficVision.Domain.Entities.User;

public class UserEmail
{
    public string Value { get; private set; }

    public UserEmail(string value)
    {
        BaseValidate.NullOrWhiteSpace(value, nameof(UserEmail));
        BaseValidate.Length(value, 40, 6, nameof(UserEmail));

        try
        {
            var addr = new MailAddress(value);

            if (addr.Address != value)
                throw new ArgumentException($"{nameof(UserEmail)} inválido: formato incorreto.");
        }
        catch
        {
            throw new ArgumentException($"{nameof(UserEmail)} inválido: formato incorreto.");
        }

        Value = value;
    }

    public static UserEmail Create(string value)
    {
        return new UserEmail(value);
    }

    public void Update(string value)
    {
        BaseValidate.NullOrWhiteSpace(value, nameof(UserEmail));
        BaseValidate.Length(value, 40, 6, nameof(UserEmail));

        try
        {
            var addr = new MailAddress(value);

            if (addr.Address != value)
                throw new ArgumentException($"{nameof(UserEmail)} inválido: formato incorreto.");
        }
        catch
        {
            throw new ArgumentException($"{nameof(UserEmail)} inválido: formato incorreto.");
        }

        Value = value;
    }
}