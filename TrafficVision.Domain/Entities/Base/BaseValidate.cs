using System.Text.RegularExpressions;

namespace TrafficVision.Domain.Entities.Base;

public static class BaseValidate
{
    public static void NullOrWhiteSpace(string value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException(propertyName + " precisa ser preenchido(a)"); }
    }

    public static void Length(string value, int maxLength, int? minLength, string propertyName)
    {
        if (minLength == null) { minLength = 0; }

        if (value.Length < minLength | value.Length > maxLength) { throw new Exception(propertyName + " precisa ter entre" + minLength + " e " + maxLength + " caracteres"); }
    }

    public static void RegexIsMatch(string value, string regex, string propertyName, string message)
    {
        if (!Regex.IsMatch(value, regex)) { throw new ArgumentException(message, propertyName); }
    }
}
