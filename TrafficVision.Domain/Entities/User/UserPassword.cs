using TrafficVision.Domain.Entities.Base;

namespace TrafficVision.Domain.Entities;

public sealed class UserPassword
{
    #region Property
    public string Value { get; private set; }
    #endregion

    #region Constructors
    public UserPassword() { }

    public UserPassword(string value)
    {
        BaseValidate.NullOrWhiteSpace(value, nameof(UserPassword));
        BaseValidate.Length(value, 16, 8, nameof(UserPassword));

        // Verifica se possue no mínimo uma maiúscula
        BaseValidate.RegexIsMatch(value, "^(?=.*[A-Z]).+$", nameof(UserPassword), " precisa conter pelo menos uma maiúscula");

        // Verifica se possue no mínimo uma minúscula
        BaseValidate.RegexIsMatch(value, "^(?=.*[a-z]).+$", nameof(UserPassword), "precisa conter pelo menos uma letra minúscula");

        // Verifica se possue pelo menos um número
        BaseValidate.RegexIsMatch(value, "^(?=.*\\d).+$", nameof(UserPassword), " precisa conter pelo menos um número");

        // Verifica se possue pelo menos um caractere especial
        BaseValidate.RegexIsMatch(value, "^(?=.*[^a-zA-Z0-9]).+$", nameof(UserPassword), " precisa conter pelo menos um caractere especial");

        Value = value;
    }
    #endregion

    #region Create/Update
    public static UserPassword Create(string value)
    {
        return new UserPassword(value);
    }

    public void Update(string value)
    {
        BaseValidate.NullOrWhiteSpace(value, nameof(UserPassword));
        BaseValidate.Length(value, 16, 8, nameof(UserPassword));

        // Verifica se possue no mínimo uma maiúscula
        BaseValidate.RegexIsMatch(value, "^(?=.*[A-Z]).+$", nameof(UserPassword), " precisa conter pelo menos uma maiúscula");

        // Verifica se possue no mínimo uma minúscula
        BaseValidate.RegexIsMatch(value, "^(?=.*[a-z]).+$", nameof(UserPassword), "precisa conter pelo menos uma letra minúscula");

        // Verifica se possue pelo menos um número
        BaseValidate.RegexIsMatch(value, "^(?=.*\\d).+$", nameof(UserPassword), " precisa conter pelo menos um número");

        // Verifica se possue pelo menos um caractere especial
        BaseValidate.RegexIsMatch(value, "^(?=.*[^a-zA-Z0-9]).+$", nameof(UserPassword), " precisa conter pelo menos um caractere especial");

        Value = value;
    }
    #endregion
}