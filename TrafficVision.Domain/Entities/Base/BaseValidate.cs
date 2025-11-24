using System.Text.RegularExpressions;

namespace TrafficVision.Domain.Entities.Base;

public static class BaseValidate
{
    public static void NullOrWhiteSpace(string value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException(propertyName + " precisa ser preenchido(a)"); }
    }

    public static void ListNullOrWhiteSpace(List<string> listValue)
    {
        foreach (var value in listValue)
        {
            NullOrWhiteSpace(value, nameof(value));
        }
    }

    public static void Length(string value, int maxLength, string propertyName, int? minLength = 0)
    {
        if (minLength == null) { minLength = 0; }

        if (value.Length < minLength | value.Length > maxLength) { throw new Exception(propertyName + " precisa ter entre" + minLength + " e " + maxLength + " caracteres"); }
    }

    public static void RegexIsMatch(string value, string regex, string propertyName, string message)
    {
        if (!Regex.IsMatch(value, regex)) { throw new ArgumentException(message, propertyName); }
    }

    public static void DateRange(DateTime initialDate, DateTime? finalDate)
    {
        if (initialDate == null)
            throw new ArgumentException($"A data inicial precisa ser informada");
            
        var today = DateTime.Today;

        if (initialDate.Date > today)
            throw new ArgumentException($"{initialDate.Date} não pode ser maior que a data atual.");

        if (finalDate.HasValue)
        {
            var endDate = finalDate.Value.Date;

            if (endDate > today)
                throw new ArgumentException($"{finalDate.Value.Date} não pode ser maior que a data atual.");

            if (endDate < initialDate.Date)
                throw new ArgumentException($"{finalDate.Value.Date} não pode ser anterior à {initialDate.Date}.");
        }
    }

}
